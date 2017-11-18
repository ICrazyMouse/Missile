using MissileText.Missile;
using System;

namespace MissileText
{
    /// <summary>
    /// 服务器交互对象
    /// </summary>
    //JSON类

    class Message
    {
        //消息类型
        private MISSILE_TYPE type { set; get; }
        //文本数据
        private String text { set; get; }
        //图片数据
        private String base64Img { set; get; }
    }
}
