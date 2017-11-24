package com.missile.exception;

import com.missile.http.params.response.Result;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;

/**
 * Created by Mario on 2017/10/16 0016.
 * 统一异常处理
 */
@SuppressWarnings("unused")
@ControllerAdvice
public class GlobalExceptionHandler {

    @ResponseBody
    @ExceptionHandler(value = Exception.class)
    public Result jsonErrorHandler(HttpServletRequest request, Exception e) {
        e.printStackTrace();
        return Result.ErrorResultWithData("服务器异常", e.getMessage());
    }

}
