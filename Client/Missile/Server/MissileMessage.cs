using Missile.Missile;
using System;

namespace Missile
{
    /// <summary>
    /// 交互信息载体
    /// </summary>
    class MissileMessage
    {
        //消息类型
        public MISSILE_TYPE missileType { set; get; }
        //文本数据
        public String missileText { set; get; }
        //图片数据
        public String missileImgUrl { set; get; }
    }
}
