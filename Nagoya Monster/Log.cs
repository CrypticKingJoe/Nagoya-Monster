using System;
using System.IO;
using System.Threading;

namespace Nagoya_Monster
{
    public static class Log
    {
        public static void Add(string Message)
        {
            if (Program.isDebugging)
            {
                try
                {
                    TextWriter textWriter = new StreamWriter("log.txt", true);
                    textWriter.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), Message));
                    textWriter.Close();
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Log.Add(string.Format("Error Saving Log: {0}", ex.Message));
                }
            }
        }
    }
}
