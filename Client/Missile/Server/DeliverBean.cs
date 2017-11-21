using Missile.Missile;
using System;

namespace Missile
{
    /// <summary>
    /// 服务器交互对象
    /// </summary>
    //JSON类

    class DeliverBean
    {
        //消息类型
        public MISSILE_TYPE missileType { set; get; }
        //文本数据
        public String text { set; get; }
        //图片数据
        public String base64Img { set; get; }
    }
}
