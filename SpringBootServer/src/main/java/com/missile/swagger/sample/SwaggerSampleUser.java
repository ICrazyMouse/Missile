package com.missile.swagger.sample;

/**
 * Created by Mario on 2017/9/26.
 * 样例 SwaggerSampleUser
 */
@SuppressWarnings("unused")
public class SwaggerSampleUser {
    private Long id;
    private String name;
    private int age;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Override
    public String toString() {
        return "SwaggerSampleUser{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", age=" + age +
                '}';
    }
}
