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
            } else {
                ws.send('No connected roomId, url：' + request.url + " CLOSE");
                ws.close();
            }
        } else {
            ws.send('No connected params, url：' + request.url + " CLOSE");
            ws.close();
        }
    } catch (error) {
    }
}
wss.on('connection', onConnect);
wss.broadcast = function broadcast(message) {
    try {
        wss.clients.forEach(function each(ws) {
            if (ws.readyState === WebSocket.OPEN) {
                var data = JSON.parse(message);
                //producer的消息发送给consumer
                if (data.type === 'producer'
                    && ws.type === 'consumer'
                    && data.roomId === ws.roomId) {
                    ws.send(JSON.stringify(data.data));
                }
            }
        });
    } catch (error) {
    }
};
console.log("WebSocket Server Started Success. /missile:8181");

//HTTP
const fs = require("fs");
const http = require("http");
var server = http.createServer(function (req, res) {
    if (req.url.indexOf('?') != -1) {
        req.url = req.url.split("?")[0];
    }
    try {
        if (req.url.startsWith("/static") && req.method === 'GET') {
            var filePath = "." + req.url;
            fs.stat(filePath, (err, stats) => {
                if (!err && stats.isFile()) {
                    var file = fs.createReadStream("." + req.url);
                    res.writeHead(200);
                    file.pipe(res);
                } else {
                    res.writeHead(404, { 'Content-Type': 'text/html;charset=utf8' });
                    res.end("404 Not Found.");
                }
            });
        } else if (req.url === '/send' && req.method === 'POST') {
            var body = '';
            req.on('data', function (chunk) {
                body += chunk;
            });
            req.on('end', function () {
                wss.broadcast(body);
            });
            res.writeHead(200, { 'Content-Type': 'text/html;charset=utf8' });
            res.end("请求成功");
        } else {
            res.writeHead(404, { 'Content-Type': 'text/html;charset=utf8' });
            res.end("404 Not Found.");
        }
    } catch (error) {
    }
});
server.listen('9090', function () {
    console.log("Http Server Started Success. 9090");
});
