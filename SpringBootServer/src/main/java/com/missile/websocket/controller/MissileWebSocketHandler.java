package com.missile.websocket.controller;

import com.alibaba.fastjson.JSON;
import com.missile.websocket.bean.ProducerWSMessage;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;

import javax.websocket.*;
import javax.websocket.server.ServerEndpoint;
import java.io.IOException;
import java.util.List;
import java.util.Map;
import java.util.concurrent.CopyOnWriteArraySet;

/**
 * Created by Mario on 2017/11/23 0023.
 * WS服务器
 */
@Component
@ServerEndpoint(value = "/ws/missile")
@SuppressWarnings("unused")
public class MissileWebSocketHandler {
    //日志
    private static Logger logger = LoggerFactory.getLogger(MissileWebSocketHandler.class);
    //concurrent包的线程安全Set
    private static CopyOnWriteArraySet<MissileWebSocketHandler> webSocketSet = new CopyOnWriteArraySet<>();
    //与某个客户端的连接会话
    private Session session;
    //连接对应的roomId
    private String roomId;
    //连接类型，producer / consumer
    private String type;

    private static final String TYPE_PRODUCER = "producer";
    private static final String TYPE_CONSUMER = "consumer";

    public MissileWebSocketHandler() {
        System.out.println("WebScoket Server Start Success Endpoint: /ws/missile");
    }

    /**
     * 连接建立
     *
     * @param session session
     */
    @OnOpen
    public void onOpen(Session session) {
        try {
            this.session = session;
            Map<String, List<String>> params = session.getRequestParameterMap();
            this.roomId = params.get("roomId") == null ? null : params.get("roomId").get(0);
            this.type = params.get("type") == null ? null : params.get("type").get(0);
            if (this.roomId != null && this.type != null) {
                webSocketSet.add(this);
                logger.info("新连接，当前在线: " + webSocketSet.size());
            } else {
                session.getBasicRemote().sendText("参数错误,无法建立连接");
                session.close();
            }
        } catch (Exception err) {
            logger.error("建立连接失败:" + session.getRequestURI());
        }
    }

    /**
     * 连接关闭
     */
    @OnClose
    public void onClose() {
        webSocketSet.remove(this);
        logger.info("连接关闭，当前在线: " + webSocketSet.size());
    }

    /**
     * 收到消息
     *
     * @param message message
     * @param session session
     */
    @OnMessage
    public void onMessage(String message, Session session) {
        logger.info("广播消息:" + message);
        broadcast(message);
    }

    /**
     * 发送消息
     *
     * @param message msg
     * @throws IOException 异常
     */
    private void sendMessage(String message) throws IOException {
        this.session.getBasicRemote().sendText(message);
        //this.session.getAsyncRemote().sendText(message);
    }

    /**
     * 发生错误
     *
     * @param session session
     * @param error   err
     */
    @OnError
    public void onError(Session session, Throwable error) {
        //不做处理
    }

    /**
     * 广播自定义消息
     *
     * @param message message
     */
    public static void broadcast(String message) {
        try {
            ProducerWSMessage producerWSMessage = JSON.parseObject(message, ProducerWSMessage.class);
            if (!producerWSMessage.getSenderType().equals(TYPE_PRODUCER)) {
                logger.info("消息类型不是producer，阻止广播，type:" + producerWSMessage.getSenderType());
                return;
            }
            logger.info("广播消息，missileType:"
                    + producerWSMessage.getMissileType()
                    + " missileText:" + producerWSMessage.getMissileText()
                    + " missileImgUrl:" + producerWSMessage.getMissileImgUrl());
            for (MissileWebSocketHandler item : webSocketSet) {
                try {
                    if (item.type.equals(TYPE_CONSUMER) && item.roomId.equals(producerWSMessage.getRoomId())) {
                        item.sendMessage(message);
                    }
                } catch (Exception err) {
                    logger.error("消息广播异常");
                    err.printStackTrace();
                }
            }
        } catch (Exception err) {
            logger.error("消息广播异常");
            err.printStackTrace();
        }
    }
}
