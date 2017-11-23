package com.missile.web.controller;

import com.alibaba.fastjson.JSON;
import com.missile.web.params.request.BroadcastMessage;
import com.missile.web.params.response.Result;
import com.missile.websocket.controller.MissileWebSocketHandler;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiImplicitParam;
import io.swagger.annotations.ApiOperation;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by Mario on 2017/11/23 0023.
 * WS广播消息用
 */
@Api(value = "/missile", description = "WS广播消息接口")
@RestController
@RequestMapping(value = "/missile")
public class WSBroadcastController {

    /**
     * 广播消息
     *
     * @param message message
     * @return Result
     */
    @ApiOperation(value = "广播消息")
    @ApiImplicitParam(name = "message", value = "消息体", required = true, dataType = "BroadcastMessage")
    @RequestMapping(value = "", method = RequestMethod.POST)
    public Result postUser(@RequestBody BroadcastMessage message) {
        //广播
        MissileWebSocketHandler.broadcast(JSON.toJSONString(message));
        return Result.SuccessResult("发送成功");
    }
}
