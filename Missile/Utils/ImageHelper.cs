using System;
using System.Drawing;
using System.IO;

namespace MissileText.Utils
{
    public class ImageHelper
    {
        /// <summary>
        /// base64转图片
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static Image Base64ToImage(String base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap res = new Bitmap(ms);
                return res;
            }
        }
    }
}
