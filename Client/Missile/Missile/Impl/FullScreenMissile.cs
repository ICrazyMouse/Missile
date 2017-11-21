using Missile.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Missile.Missile.Impl
{
    class FullScreenMissile : BaseMissile
    {
        //文字标题
        private String title;
        //图片纹理对象
        private Image img;
        //初始化时间
        private long tsInit;

        /// <summary>
        /// 构造函数，Base64字符串
        /// </summary>
        /// <param name="base64Img"></param>
        /// <param name="title"></param>
        public FullScreenMissile(String base64Img, String title = null) : this(ImageHelper.Base64ToImage(base64Img), title) { }
        /// <summary>
        /// 构造函数 传入image对象
        /// </summary>
        /// <param name="img"></param>
        /// <param name="title"></param>
        public FullScreenMissile(Image img, String title = null)
        {
            this.title = title;
            this.img = img;
        }
        /// <summary>
        /// 修正图片尺寸
        /// 尽量大地显示在屏幕内
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Size FixImgSize(Size size)
        {
            Size scSize = Screen.PrimaryScreen.Bounds.Size;
            scSize.Width -= 150;
            scSize.Height -= 150;
            //如果小了，先放大
            if (size.Width < scSize.Width)
            {
                var scale = ((float)scSize.Width) / size.Width;
                size.Width = scSize.Width;
                size.Height = (int)(size.Height * scale);
            }
            if (size.Height < scSize.Height)
            {
                var scale = ((float)scSize.Height) / size.Height;
                size.Height = scSize.Height;
                size.Width = (int)(size.Width * scale);
            }
            //超宽缩宽，超长缩长
            if (size.Width > scSize.Width)
            {
                var scale = ((float)scSize.Width) / size.Width;
                size.Width = scSize.Width;
                size.Height = (int)(size.Height * scale);
            }
            if (size.Height > scSize.Height)
            {
                var scale = ((float)scSize.Height) / size.Height;
                size.Height = scSize.Height;
                size.Width = (int)(size.Width * scale);
            }
            return size;
        }
        /// <summary>
        /// 修正位置,霸屏图片位于正中央
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Point FixPos(Size size)
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - size.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - size.Height) / 2;
            if (this.title != null)
                y += 50;
            return new Point(x, y);
        }
        /// <summary>
        /// 重写开始
        /// 开始计时
        /// </summary>
        public override void Start()
        {
            base.Start();
            this.tsInit = DateTime.Now.Ticks;
        }
        /// <summary>
        /// 重写动画过程
        /// 霸屏图片静止不动
        /// </summary>
        public override void NextFrame() { }
        /// <summary>
        /// 重写结束方法
        /// 生命周期2.5s
        /// </summary>
        /// <returns></returns>
        public override bool IsOver()
        {
            if ((DateTime.Now.Ticks - this.tsInit) > 25000000)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 霸屏图片 展示2.3s后，算ShowAll
        /// </summary>
        /// <returns></returns>
        public override bool IsShowAll()
        {
            if ((DateTime.Now.Ticks - this.tsInit) > 23000000)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 渲染尺寸
        /// </summary>
        /// <returns></returns>
        public override Size RenderSize()
        {
            return Screen.PrimaryScreen.Bounds.Size;
        }
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="graph"></param>
        public override void Render(Graphics graph)
        {
            //红色背景，黄色"霸屏"字的背景图
            graph.DrawImage(Properties.Resources.FullScreen, new Rectangle(new Point(0, 0), Screen.PrimaryScreen.Bounds.Size));
            //画霸屏图片
            Size fixSize = this.FixImgSize(this.img.Size);
            graph.DrawImage(this.img, new Rectangle(this.FixPos(fixSize), fixSize));
            //标题
            if (this.title != null)
            {
                var font = new Font("微软雅黑", 45, FontStyle.Bold);
                //用一个画板获取字符串纹理的尺寸
                SizeF size = graph.MeasureString(this.title, font);
                //画标题背景
                PointF pos = new PointF(Screen.PrimaryScreen.Bounds.Width / 2 - size.Width / 2, 25);
                graph.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point((int)pos.X, (int)pos.Y), new Size((int)size.Width, (int)size.Height)));
                graph.DrawString(this.title, font, new SolidBrush(Color.Red), pos);
            }
        }
        /// <summary>
        /// 霸屏
        /// </summary>
        /// <returns></returns>
        public override MISSILE_TYPE Type()
        {
            return MISSILE_TYPE.FS_IMAGE;
        }
    }
}
