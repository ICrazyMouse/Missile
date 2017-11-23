package com.missile.web.controller;

import com.missile.web.params.response.Result;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

import javax.servlet.http.HttpServletRequest;
import java.io.File;
import java.io.FileOutputStream;
import java.util.UUID;

/**
 * Created by Mario on 2017/11/23 0023.
 * 微信小程序上传图片
 */
@Api(value = "/upload", description = "微信小程序上传图片")
@RestController
@RequestMapping(value = "/upload")
public class WXMiniUploadImgController {
    //日志
    private static Logger logger = LoggerFactory.getLogger(WXMiniUploadImgController.class);
    //存储路径
    @Value("${upload.wxmini.image.savepath}")
    private String savePath;
    //访问前缀
    @Value("${upload.wxmini.image.uri.prefix}")
    private String uriPrefix;

    /**
     * 微信小程序上传图片
     *
     * @param uploadFile 文件
     * @return Result
     */
    @RequestMapping(value = "/WXMiniImageUpload", method = RequestMethod.POST)
    @ApiOperation("微信小程序上传图片")
    public Result BankApprovalDataImport(@RequestParam MultipartFile uploadFile) {
        try {
            if (!uploadFile.isEmpty()) {
                String fileName = UUID.randomUUID() + uploadFile.getOriginalFilename();
                fileName = fileName.replaceAll("-", "");
                File targetFile = new File(savePath);
                if (!targetFile.exists()) {
                    boolean mkdirsOk = targetFile.mkdirs();
                    if (!mkdirsOk) {
                        return Result.ErrorResult("服务器异常:文件目录创建失败.");
                    }
                }
                FileOutputStream fsOut = new FileOutputStream(savePath + fileName);
                fsOut.write(uploadFile.getBytes());
                fsOut.flush();
                fsOut.close();
                logger.info("图片上传成功,保存路劲:" + savePath + fileName);
                return Result.SuccessResultWithData("上传成功",uriPrefix+fileName);
            } else {
                return Result.ErrorResult("文件为空");
            }
        } catch (Exception err) {
            err.printStackTrace();
            return Result.ErrorResult("服务器异常");
        }
    }
}
