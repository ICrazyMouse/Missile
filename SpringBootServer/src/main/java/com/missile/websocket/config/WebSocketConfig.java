package com.missile.websocket.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.socket.server.standard.ServerEndpointExporter;

/**
 * Created by Mario on 2017/11/23 0023.
 * WS 配置类
 */
@Configuration
public class WebSocketConfig {
    /**
     * 注入ServerEndpointExporter
     * @return ServerEndpointExporter
     */
    @Bean
    public ServerEndpointExporter serverEndpointExporter() {
        return new ServerEndpointExporter();
    }
}