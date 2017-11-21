using System;
using System.Drawing;

namespace Missile.Missile.Impl
{
    class TextMissile : BaseMissile
    {
        //文本内容
        private String content { set; get; }
        //颜色
        private Color color { set; get; }
        //字体
        private Font font { set; get; }

        public TextMissile(String content) {
            this.content = content;
            this.color = this.InitialColor();
            this.font = this.InitialFont();
        }
        /// <summary>
        /// 随机初始颜色
        /// </summary>
        /// <returns></returns>
        private Color InitialColor()
        {
            int r = new Random(DateTime.Now.Millisecond).Next(1, 7);
            Color res = Color.White;
            switch (r)
            {
                case 1:
                    res = Color.White;
                    break;
                case 2:
                    res = Color.GhostWhite;
                    break;
                case 3:
                    res = Color.Yellow;
                    break;
                case 4:
                    res = Color.DeepPink;
                    break;
                case 5:
                    res = Color.DarkOrange;
                    break;
                case 6:
                    res = Color.Cyan;
                    break;
                default:
                    break;
            }
            return res;
        }
        /// <summary>
        /// 初始字体
        /// </summary>
        /// <returns></returns>
        private Font InitialFont()
        {
            int fontSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 24 + 10;
            return new Font("微软雅黑", fontSize, FontStyle.Bold);
        }
        /// <summary>
        /// 计算文本纹理尺寸
        /// </summary>
        /// <param name="content"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        private Size CalcSize(string content, Font font)
        {
            //用一个画板获取字符串纹理的尺寸
            //初始化画面位图
            var bitmap = new Bitmap(1, 1);
            //初始化画板
            var graph = Graphics.FromImage(bitmap);
            SizeF size = graph.MeasureString(content, font);
            return new Size((int)size.Width, (int)size.Height);
        }
        /// <summary>
        /// 渲染尺寸
        /// </summary>
        /// <returns></returns>
        public override Size RenderSize()
        {
            return this.CalcSize(this.content, this.font);
        }
        /// <summary>
        /// 渲染
        /// </summary>
        public override void Render(Graphics graph)
        {
            graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graph.DrawString(this.content, this.font, new SolidBrush(this.color), new PointF());
        }
        /// <summary>
        /// 文本类型
        /// </summary>
        /// <returns></returns>
        public override MISSILE_TYPE Type()
        {
            return MISSILE_TYPE.TEXT;
        }
    }
}
