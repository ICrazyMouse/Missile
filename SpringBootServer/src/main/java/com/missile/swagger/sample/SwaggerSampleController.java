package com.missile.swagger.sample;

import io.swagger.annotations.Api;
import io.swagger.annotations.ApiImplicitParam;
import io.swagger.annotations.ApiImplicitParams;
import io.swagger.annotations.ApiOperation;
import org.springframework.web.bind.annotation.*;

import java.util.*;

/**
 * Created by Mario on 2017/9/25.
 * 测试用Controller
 * Swagger 用例
 */
@Api(value = "/sample/users", description = "样例Swagger样例")
@RestController
@RequestMapping(value = "/sample/users")
public class SwaggerSampleController {

    private static Map<Long, SwaggerSampleUser> users = Collections.synchronizedMap(new HashMap<Long, SwaggerSampleUser>());

    @ApiOperation(value = "获取用户列表", notes = "获取用户列表notes")
    @RequestMapping(value = {""}, method = RequestMethod.GET)
    public List<SwaggerSampleUser> getUserList() {
        return new ArrayList<>(users.values());
    }

    @ApiOperation(value = "创建用户", notes = "根据User对象创建用户")
    @ApiImplicitParam(name = "swaggerSampleUser", value = "用户详细实体user", required = true, dataType = "SwaggerSampleUser")
    @RequestMapping(value = "", method = RequestMethod.POST)
    public String postUser(@RequestBody SwaggerSampleUser swaggerSampleUser) {
        users.put(swaggerSampleUser.getId(), swaggerSampleUser);
        return "success";
    }

    //pathVariable 参数需指定paramType = "path"
    // paramType 有五个可选值:path, query, body, header, form
    @ApiOperation(value = "获取用户详细信息", notes = "根据url的id来获取用户详细信息")
    @ApiImplicitParam(name = "id", value = "用户ID", required = true, dataType = "Long", paramType = "path")
    @RequestMapping(value = "/{id}", method = RequestMethod.GET)
    public SwaggerSampleUser getUser(@PathVariable Long id) {
        return users.get(id);
    }

    @ApiOperation(value = "更新用户详细信息", notes = "根据url的id来指定更新对象，并根据传过来的user信息来更新用户详细信息")
    @ApiImplicitParams({
            @ApiImplicitParam(name = "id", value = "用户ID", required = true, dataType = "Long", paramType = "path"),
            @ApiImplicitParam(name = "swaggerSampleUser", value = "用户详细实体user", required = true, dataType = "SwaggerSampleUser", paramType = "body")
    })
    @RequestMapping(value = "/{id}", method = RequestMethod.PUT)
    public String putUser(@PathVariable Long id, @RequestBody SwaggerSampleUser swaggerSampleUser) {
        SwaggerSampleUser u = users.get(id);
        u.setName(swaggerSampleUser.getName());
        u.setAge(swaggerSampleUser.getAge());
        users.put(id, u);
        return "success";
    }

    @ApiOperation(value = "删除用户", notes = "根据url的id来指定删除对象")
    @ApiImplicitParam(name = "id", value = "用户ID", required = true, dataType = "Long", paramType = "path")
    @RequestMapping(value = "/{id}", method = RequestMethod.DELETE)
    public String deleteUser(@PathVariable Long id) {
        users.remove(id);
        return "success";
    }
}
