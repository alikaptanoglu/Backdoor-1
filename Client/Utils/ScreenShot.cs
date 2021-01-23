using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Client.Utils
{
    internal class ScreenShot
    {
        internal string Save()
        {
            using (MemoryStream _Memory_Stream = new MemoryStream())
            {
                using (Bitmap _Bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics _Graphis = Graphics.FromImage(_Bitmap))
                    {
                        _Graphis.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0x0, 0x0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                        _Bitmap.Save(_Memory_Stream, ImageFormat.Jpeg);

                        return Convert.ToBase64String(_Memory_Stream.ToArray());
                    }
                }
            }
        }
    }
}