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
using System.Net;
using System.Diagnostics;
using System.Threading;
using IWshRuntimeLibrary;


namespace Installer
{
    public partial class frmInstall : Form
    {
        public frmInstall()
        {
            InitializeComponent();
            btnInstall.Visible = false;
            btnContinue.Visible = false;
            pBar.Visible = false;
        }

        private void btnStep1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFileDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string installDir = folderBrowserDialog1.SelectedPath;
                btnStep1.Visible = false;
                btnInstall.Visible = true;
                pBar.Visible = false;
                btnContinue.Visible = false;
                lblMain.Text = "Trinity WoW will be installed in " + installDir; 
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            DoWorkEventHandler workEventHandler = new DoWorkEventHandler(this.worker_DoWork);
            backgroundWorker.DoWork += workEventHandler;
            ProgressChangedEventHandler changedEventHandler = new ProgressChangedEventHandler(this.worker_ProgressChanged);
            backgroundWorker.ProgressChanged += changedEventHandler;
            RunWorkerCompletedEventHandler completedEventHandler = new RunWorkerCompletedEventHandler(this.worker_Complete);
            backgroundWorker.RunWorkerCompleted += completedEventHandler;
            backgroundWorker.RunWorkerAsync();
            pBar.Visible = true;
            btnInstall.Visible = false;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(200);
            }
            string installURL = "http://www.trinitywow.org/game/install/legion/";

                Directory.CreateDirectory(folderBrowserDialog1.SelectedPath + "\\WTF");
                new WebClient().DownloadFile(installURL + "connection_patcher.exe", folderBrowserDialog1.SelectedPath + "\\connection_patcher.exe");
                new WebClient().DownloadFile(installURL + "common.dll", folderBrowserDialog1.SelectedPath + "\\common.dll");
                new WebClient().DownloadFile(installURL + "libeay32.dll", folderBrowserDialog1.SelectedPath + "\\libeay32.dll");
                new WebClient().DownloadFile(installURL + "libmysql.dll", folderBrowserDialog1.SelectedPath + "\\libmysql.dll");
                new WebClient().DownloadFile(installURL + "libssl32.dll", folderBrowserDialog1.SelectedPath + "\\libssl32.dll");
                new WebClient().DownloadFile(installURL + "ssleay32.dll", folderBrowserDialog1.SelectedPath + "\\ssleay32.dll");
                new WebClient().DownloadFile(installURL + "Wow.exe", folderBrowserDialog1.SelectedPath + "\\Wow.exe");
                new WebClient().DownloadFile(installURL + "Launcher.exe", folderBrowserDialog1.SelectedPath + "\\Launcher.exe");
                new WebClient().DownloadFile(installURL + "WTF/Config.wtf", folderBrowserDialog1.SelectedPath + "\\WTF\\Config.wtf");

            // Add the desktop ShortCut
            CreateShortcut("Trinity WoW", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), folderBrowserDialog1.SelectedPath);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pBar.Value = e.ProgressPercentage;
            this.lblMain.Text = "Downloaded " + e.ProgressPercentage.ToString() + "%";
            this.btnExit.Text = "Cancel";
        }

        private void worker_Complete(object sender, EventArgs e)
        {
            this.lblMain.Text = "Install Complete, Click Continue";
            this.pBar.Visible = false;
            this.btnContinue.Visible = true;
            this.btnExit.Visible = false;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(folderBrowserDialog1.SelectedPath + "\\WoW.mfil"))
            {
                this.installWoW();
            }
            if (!System.IO.File.Exists(folderBrowserDialog1.SelectedPath + "\\Wow_Patched.exe"))
            {
                Process.Start(folderBrowserDialog1.SelectedPath + "\\connection_patcher.exe", folderBrowserDialog1.SelectedPath + "\\Wow.exe");
            }
            else
            {
                btnContinue.Visible = false;
                btnExit.Visible = true;
                lblMain.Text = "Thank you for joining the Twisted Trinity Family, Enjoy!\nPlease create an account if you have not already done so,";
            }
        }

        // Install WoW
        private void installWoW()
        {
            Process.Start(folderBrowserDialog1.SelectedPath + "\\Wow.exe");
            this.Close();
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Trinity Wow Legion Launcher";   // The description of the shortcut
            shortcut.IconLocation = targetFileLocation + @"\\Launcher.exe";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation + @"\\Launcher.exe";                 // The path of the file that will launch when the shortcut is run
            shortcut.WorkingDirectory = targetFileLocation;
            shortcut.Save();                                    // Save the shortcut
        }
    }
}
