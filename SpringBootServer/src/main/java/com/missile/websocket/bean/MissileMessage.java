package com.missile.websocket.bean;

/**
 * Created by Mario on 2017/11/23 0023.
 * WS消息载体
 */
@SuppressWarnings("unused")
public class MissileMessage {
    private int missileType;
    private String missileText;
    private String missileImgUrl;
    private String avatar;
    private String nickName;

    public String getAvatar() {
        return avatar;
    }

    public void setAvatar(String avatar) {
        this.avatar = avatar;
    }

    public String getNickName() {
        return nickName;
    }

    public void setNickName(String nickName) {
        this.nickName = nickName;
    }

    public int getMissileType() {
        return missileType;
    }

    public void setMissileType(int missileType) {
        this.missileType = missileType;
    }

    public String getMissileText() {
        return missileText;
    }

    public void setMissileText(String missileText) {
        this.missileText = missileText;
    }

    public String getMissileImgUrl() {
        return missileImgUrl;
    }

    public void setMissileImgUrl(String missileImgUrl) {
        this.missileImgUrl = missileImgUrl;
    }
}
