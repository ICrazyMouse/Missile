using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Missile.Utils
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
            if (base64 == null) return new Bitmap(1, 1);
            byte[] bytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap res = new Bitmap(ms);
                return res;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image fetchUrlImage(String url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("url");
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                WebResponse wp = request.GetResponse();
                Image img = Image.FromStream(wp.GetResponseStream());
                return img;
            }
            catch
            {
                return new Bitmap(1, 1);
            }
        }
    }
}
