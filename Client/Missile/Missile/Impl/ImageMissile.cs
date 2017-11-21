using Missile.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Missile.Missile.Impl
{
    class ImageMissile : BaseMissile
    {
        //图片纹理对象
        private Image img;

        /// <summary>
        /// 构造函数 传入base64字符串
        /// </summary>
        /// <param name="base64"></param>
        public ImageMissile(String base64) : this(ImageHelper.Base64ToImage(base64)){ }
        /// <summary>
        /// 构造函数 传入Image对象
        /// </summary>
        /// <param name="img"></param>
        public ImageMissile(Image img)
        {
            this.img = img;
        }
        /// <summary>
        /// 渲染尺寸
        /// 修正图片尺寸，不得超出屏幕
        /// 推荐图片宽高都在屏幕尺寸1/3内
        /// </summary>
        /// <returns></returns>
        public override Size RenderSize()
        {
            Size res = this.img.Size;
            Size scs = Screen.PrimaryScreen.Bounds.Size;
            if (res.Height <= scs.Height / 3 && res.Width <= scs.Width / 3)
            {
                return res;
            }
            if (res.Height > scs.Height / 3)
            {
                float scale = ((float)(scs.Height / 3)) / ((float)(res.Height));
                res.Width = (int)(res.Width * scale);
                res.Height = scs.Height / 3;
            }
            if (res.Width > scs.Width / 3)
            {
                float scale = ((float)(scs.Width / 3)) / ((float)(res.Width));
                res.Width = (int)(res.Width * scale);
                res.Width = scs.Width / 3;
            }
            return res;
        }
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="graph"></param>
        public override void Render(Graphics graph)
        {
            graph.DrawImage(this.img, new Rectangle(new Point(), this.RenderSize()));
        }
        /// <summary>
        /// 图片类型
        /// </summary>
        /// <returns></returns>
        public override MISSILE_TYPE Type()
        {
            return MISSILE_TYPE.IMAGE;
        }
    }
}
