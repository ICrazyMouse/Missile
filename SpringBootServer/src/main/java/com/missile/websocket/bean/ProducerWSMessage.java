package com.missile.websocket.bean;

/**
 * Created by Mario on 2017/11/23 0023.
 * 生产者消息载体
 */
@SuppressWarnings("unused")
public class ProducerWSMessage extends MissileMessage {

    private String roomId;
    private String senderType;

    public String getRoomId() {
        return roomId;
    }

    public void setRoomId(String roomId) {
        this.roomId = roomId;
    }

    public String getSenderType() {
        return senderType;
    }

    public void setSenderType(String senderType) {
        this.senderType = senderType;
    }
}
