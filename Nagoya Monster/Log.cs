using System;
using System.IO;
using System.Threading;

namespace Nagoya_Monster
{
    public static class Log
    {
        public static void Add(string Message, string dateTime = "")
        {
            if (dateTime == "")
                dateTime = DateTime.Now.ToString();

            for (int i = 0; i < 4; ++i)
            {
                try
                {
                    TextWriter textWriter = new StreamWriter(Program.LogPath, true);
                    textWriter.WriteLine(string.Format("[{0}] {1}", dateTime, Message));
                    textWriter.Close();
                    break;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Add(string.Format("Error Saving Log: {0}", ex.Message));
                }
            }
        }
    }
}
