package com.missile.http.params.response;

/**
 * Created by Mario on 2017/9/26.
 * 统一返回类
 */
@SuppressWarnings("unused")
public class Result {
    public static final int SUCCESS_CODE = 1;
    public static final int ERROR_CODE = 0;
    public static final int NO_LOGIN = -1;

    private int code;//状态码
    private String message;//信息
    private Object data;//具体数据

    public Result(int code, String message) {
        this.code = code;
        this.message = message;
    }

    public Result(int code, String message, Object data) {
        this.code = code;
        this.message = message;
        this.data = data;
    }

    public int getCode() {
        return code;
    }

    public void setCode(int code) {
        this.code = code;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Object getData() {
        return data;
    }

    public void setData(Object data) {
        this.data = data;
    }

    public static Result SuccessResult(String message) {
        return new Result(Result.SUCCESS_CODE, message);
    }

    public static Result ErrorResult(String message) {
        return new Result(Result.ERROR_CODE, message);
    }

    public static Result SuccessResultWithData(String message, Object data) {
        return new Result(Result.SUCCESS_CODE, message, data);
    }

    public static Result ErrorResultWithData(String message, Object data) {
        return new Result(Result.ERROR_CODE, message, data);
    }
}
