using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Server.Utils
{
    internal class ScreenShot
    {
        internal void Save(string _ScreenShot)
        {
            using (MemoryStream _Memory_Stream = new MemoryStream())
            {
                string _Time = DateTime.Now.ToString("HHmmss");
                byte[] _Temp = Convert.FromBase64String(_ScreenShot);

                _Memory_Stream.Position = 0x0;
                _Memory_Stream.Write(_Temp, 0x0, _Temp.Length);

                using (Image _Image = Image.FromStream(_Memory_Stream))
                {
                    _Image.Save($"{_Time}.jpeg", ImageFormat.Jpeg);
                }
            }
        }
    }
}