using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Nagoya_Monster
{
    static class Screenshot
    {
        public static void TakeScreenShot()
        {
            foreach(Screen monitor in Screen.AllScreens)
            {
                Bitmap bitmap = new Bitmap(monitor.Bounds.Width, monitor.Bounds.Height);
                Graphics.FromImage(bitmap).CopyFromScreen(monitor.Bounds.X, monitor.Bounds.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);

                bitmap.Save(string.Format("screenshot-{0}.png", System.DateTime.Now.Ticks.ToString()), ImageFormat.Png);
            }
        }
    }
}
