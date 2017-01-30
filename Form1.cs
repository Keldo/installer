using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace INSTALL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
            button1.Text = "Exit";
            if (!Directory.Exists("Legion"))
            {
                Directory.CreateDirectory("Legion");
            }
            Directory.SetCurrentDirectory("Legion");
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(200);
            }


            // Start downloaing the Private Server Patch Files
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/connection_patcher.exe", "connection_patcher.exe");
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/libeay32.dll", "libeay32.dll");
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/libmysql.dll", "libmysql.dll");
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/libssl32.dll", "libssl32.dll");
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/ssleay32.dll", "ssleay32.dll");
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/common.dll", "common.dll");

            // Create the WTF Directory for Configuration
            Directory.CreateDirectory("WTF");
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/WTF/Config.wtf", @"WTF\Config.wtf");

            // Get the Launcher
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/Launcher.exe", "Launcher.exe");

            // All game content would be downloaded here, using the Installer for test purposes.
            new WebClient().DownloadFile("http://www.trinitywow.org/game/install/legion/Wow.exe", "Wow.exe");
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            label1.Text = "Downloaded " + e.ProgressPercentage.ToString() + "%";
            button1.Text = "Cancel";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                Process.Start("connection_patcher.exe", "Wow.exe");
            }
            catch
            {
                MessageBox.Show("Cannot find Wow.exe");
            }
        }
    }
}
