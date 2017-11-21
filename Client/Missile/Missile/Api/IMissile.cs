using System.Drawing;

namespace Missile.Missile.Api
{
    public interface IMissile
    {
        //开始
        void Start();
        //显示
        void Show();
        //隐藏
        void Hide();
        //结束
        void Close();
        //类型
        MISSILE_TYPE Type();
        //移动速度
        int GetSpeed();
        //设置初始位置
        void SetStartPos(Point pos);
        //获取位置
        Point getPos();
        //是否已全部展示
        bool IsShowAll();
        //是否结束
        bool IsOver();
    }
}
