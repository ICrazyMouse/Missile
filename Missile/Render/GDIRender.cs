using System;
using System.Drawing;

namespace MissileText.Render
{
    class GDIRender
    {
        private
            IntPtr oldBits;
            IntPtr screenDC;
            IntPtr hBitmap;
            IntPtr memDc;
            IntPtr handle;
        public GDIRender(IntPtr handle) {
            this.handle = handle;
            oldBits = IntPtr.Zero;
            hBitmap = IntPtr.Zero;
        }

        public void Render(Bitmap bitmap, int left, int top) {
            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("The picture must be 32bit picture with alpha channel.");
            try
            {
                screenDC = Win32.GetDC(IntPtr.Zero);
                memDc = Win32.CreateCompatibleDC(screenDC);

                Win32.Point topLoc = new Win32.Point(left, top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;
                Win32.UpdateLayeredWindow(handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }
    }
}
