using MissileText.Missile.Api;
using MissileText.Render;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MissileText.Missile.Impl
{
    public abstract partial class BaseMissile : Form, IMissile
    {
        //图像
        private Bitmap bitmap;
        //画板
        private Graphics graph;
        //GDI渲染对象
        private GDIRender gdiRender;
        //Show() 方法会初始化Location为0,0
        private Point showLocation;
        public BaseMissile()
        {
            InitializeComponent();
            //无边框
            this.FormBorderStyle = FormBorderStyle.None;
            //减少闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //用户绘制
            this.SetStyle(ControlStyles.UserPaint, true);
            //双缓冲
            this.SetStyle(ControlStyles.DoubleBuffer, true); 
            //更新样式
            this.UpdateStyles();
            //初始化Render
            this.gdiRender = new GDIRender(this.Handle);
            //不是顶级控件
            this.TopLevel = false;
        }
        /// <summary>
        /// 扩展窗口样式值的安位组合
        /// 使窗体透明
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOOLWINDOW = 0x00000080;
                const int WS_EX_LAYERED = 0x00080000;
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle = cParms.ExStyle | WS_EX_LAYERED | WS_EX_TOOLWINDOW;
                return cParms;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            this.NextFrame();
        }
        /// <summary>
        /// 类型
        /// </summary>
        /// <returns></returns>
        public abstract MISSILE_TYPE Type();
        /// <summary>
        /// 大小
        /// </summary>
        /// <returns></returns>
        public abstract Size RenderSize();
        /// <summary>
        /// 渲染,由子类完成
        /// 保证窗体可全部显示渲染纹理
        /// </summary>
        public abstract void Render(Graphics graph);
        /// <summary>
        /// 开始
        /// </summary>
        public virtual void Start()
        {
            //显示，会初始化Location0,0
            this.Show();
            this.Location = this.showLocation;
            //修改窗体大小
            this.Size = this.RenderSize();
            //初始化画面位图
            this.bitmap = new Bitmap(this.Size.Width, this.Size.Height);
            //初始化画板
            this.graph = Graphics.FromImage(this.bitmap);
            //消除黑边
            this.graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.Render(this.graph);
            this.gdiRender.Render(this.bitmap, 0, 0);
            //开始移动
            this.timerUpdate.Start();
        }
        /// <summary>
        /// 速度默认5
        /// </summary>
        /// <returns></returns>
        public virtual int GetSpeed()
        {
            return 5;
        }
        /// <summary>
        /// 设置初始位置
        /// </summary>
        /// <param name="pos"></param>
        public virtual void SetStartPos(Point pos)
        {
            this.showLocation = pos;
        }
        /// <summary>
        /// 获取当前位置
        /// </summary>
        /// <returns></returns>
        public virtual Point getPos()
        {
            return this.Location;
        }
        /// <summary>
        /// 下一帧，可设置动画等
        /// </summary>
        public virtual void NextFrame()
        {
            Point location = this.Location;
            location.X -= this.GetSpeed();
            this.Location = location;
        }
        /// <summary>
        /// 是否已全部显示，可释放占用通道
        /// </summary>
        /// <returns></returns>
        public virtual bool IsShowAll()
        {
            return (Screen.PrimaryScreen.Bounds.Width - this.Location.X) > (this.Size.Width + 50);
        }
        /// <summary>
        /// 是否结束
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOver()
        {
            return this.Location.X < -this.Size.Width;
        }
    }
}
