//LOG
var log4js = require('log4js');
log4js.configure({
    appenders: {
        missile: {
            type: 'file',
            filename: './logs/access.log',
            maxLogSize: 1024 * 1024 * 10,//一个文件的大小，超出后会自动新生成一个文件 1024 * 1024 * 10 = 10MB
            backups: 3,//备份的文件数量
        }
    },
    replaceConsole: true,
    categories: { default: { appenders: ['missile'], level: 'INFO' } }
});
var logger = log4js.getLogger('missile');
//WS
const WebSocket = require('ws');
const WebSocketServer = WebSocket.Server;
var wss = new WebSocketServer({
    port: 8181,
    path: "/missile",
    verifyClient: null
});
var onMessage = function (message) {
    wss.broadcast(message);
}
var onConnect = function (ws, request) {
    try {
        var params = request.url.split('?')[1];
        if (params) {
            var roomId;
            var type;
            params.split('&').forEach(element => {
                if (element.split('=')[0] === 'roomId') {
                    roomId = element.split('=')[1];
                } else if (element.split('=')[0] === 'type') {
                    type = element.split('=')[1];
                }
            });
            if (roomId && type) {
                ws.type = type;
                ws.roomId = roomId;
                ws.on('message', onMessage);
                logger.info("New Client Connected, url:" + request.url);
                logger.info("Total Clients Count:" + wss.clients.size);
            } else {
                ws.send('No connected roomId, url：' + request.url + " CLOSE");
                logger.info('No connected roomId, url：' + request.url + " CLOSE");
                ws.close();
            }
        } else {
            ws.send('No connected params, url：' + request.url + " CLOSE");
            logger.info('No connected params, url：' + request.url + " CLOSE");
            ws.close();
        }
    } catch (error) {
        logger.error("WSS连接异常:" + error);
    }
}
wss.on('connection', onConnect);
wss.broadcast = function broadcast(message) {
    try {
        var data = JSON.parse(message);
        logger.info("WSS广播消息: type:" + data.type
            + " roomId:" + data.roomId
            + " missileType:" + data.data.missileType
            + " missileText:" + data.data.text
            + " missileImage:" + (data.data.base64Img ? "Yes" : "No"));
        wss.clients.forEach(function each(ws) {
            if (ws.readyState === WebSocket.OPEN) {
                //producer的消息发送给consumer
                if (data.type === 'producer'
                    && ws.type === 'consumer'
                    && data.roomId === ws.roomId) {
                    ws.send(JSON.stringify(data.data));
                }
            }
        });
    } catch (error) {
        logger.error("WSS广播异常:" + error);
    }
};
console.log("WebSocket Server Started Success. /missile:8181");
logger.info("WebSocket Server Started Success. /missile:8181");

//HTTP
const fs = require("fs");
const http = require("http");
const uuid = require('uuid');
var server = http.createServer(function (req, res) {
    if (req.url.indexOf('?') != -1) {
        req.url = req.url.split("?")[0];
    }
    try {
        if (req.url === '/send' && req.method === 'POST') {
            //发送弹幕
            var body = '';
            req.on('data', function (chunk) {
                body += chunk;
            });
            req.on('end', function () {
                wss.broadcast(body);
            });
            res.writeHead(200, { 'Content-Type': 'text/html;charset=utf8' });
            res.end("请求成功");
        } else if (req.url === '/uploadImg' && req.method === 'POST') {
            //上传图片
            var filename = uuid.v1().toString().replace(new RegExp('-', "g"), '');
            var out = fs.createWriteStream("/usr/share/nginx/missile/upload/img/" + filename);
            req.on('data', function (chunk) {
                out.write(chunk);
            });
            req.on('end', function () {
                out.end();
                res.writeHead(200, { 'Content-Type': 'text/html;charset=utf8' });
                res.end("/upload/img/" + filename);
            });
        } else if (req.method === 'GET') {
            var filePath = "/usr/share/nginx/missile" + req.url;
            fs.stat(filePath, (err, stats) => {
                if (!err && stats.isFile()) {
                    var file = fs.createReadStream(filePath);
                    res.writeHead(200);
                    file.pipe(res);
                } else {
                    res.writeHead(404, { 'Content-Type': 'text/html;charset=utf8' });
                    res.end("404 Not Found.");
                }
            });
        } else {
            res.writeHead(404, { 'Content-Type': 'text/html;charset=utf8' });
            res.end("404 Not Found.");
        }
    } catch (error) {
        logger.error("HTTP异常:" + error);
    }
});
server.listen('9090', function () {
    console.log("Http Server Started Success. 9090");
    logger.info("Http Server Started Success. 9090");
});
