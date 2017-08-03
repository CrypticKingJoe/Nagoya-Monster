namespace Nagoya_Monster
{
    class Program
    {
        public static bool isDebugging = true;
        public static bool isRunning = true;  

        private static void Main(string[] args)
        {
            Log.Add("Nagoya Monster Started");
            Keylog.Start();
            Log.Add("Nagoya Monster Finished");
        }
    }
}
