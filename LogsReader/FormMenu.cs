using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace LogsReader
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void ButtonExtract_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "Downloads",
                Filter = "zip (*.zip)|*.zip|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                Multiselect = false
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
                {
                    RootFolder = Environment.SpecialFolder.Desktop
                };

                folderBrowserDialog.ShowDialog();

                ZipFile.ExtractToDirectory(openFileDialog1.FileName, folderBrowserDialog.SelectedPath);

                DirectoryInfo di = new DirectoryInfo(folderBrowserDialog.SelectedPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    if (file.Name.EndsWith("dat"))
                        file.MoveTo(folderBrowserDialog.SelectedPath + @"\" + file.Name.Substring(0, file.Name.Length - 4) + ".txt");
                }

                di = new DirectoryInfo(folderBrowserDialog.SelectedPath + @"\TaskRunnerExplorer");

                foreach (FileInfo file in di.GetFiles())
                {
                    if (file.Name.EndsWith("dll"))
                        file.MoveTo(folderBrowserDialog.SelectedPath + @"\TaskRunnerExplorer\" + file.Name.Substring(0, file.Name.Length - 4) + ".png");
                }

            }
        }
    }
}
