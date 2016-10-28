using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using EPS.Libraries.ClientLibrary.HttpUtils;

namespace FileDownloaderTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainClass
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			try
			{
				//turn on themes in windows >xp
				Application.EnableVisualStyles();
				Application.DoEvents();
                Directory.CreateDirectory(@"C:\Trinity\Legion");
                Directory.CreateDirectory(@"C:\Trinity\Legion\data");
                Directory.CreateDirectory(@"C:\Trinity\Legion\data\config");
                Directory.CreateDirectory(@"C:\Trinity\Legion\data\data");
                Directory.CreateDirectory(@"C:\Trinity\Legion\data\indices");
                Directory.CreateDirectory(@"C:\Trinity\Legion\data\patch");
                Directory.CreateDirectory(@"C:\Trinity\Legion\Logs");
                Directory.CreateDirectory(@"C:\Trinity\Legion\Interface");
                Directory.CreateDirectory(@"C:\Trinity\Legion\Interface\AddOns");
                Directory.CreateDirectory(@"C:\Trinity\Legion\WTF");
                Directory.CreateDirectory(@"C:\Trinity\Legion\Errors");
                Directory.CreateDirectory(@"C:\Trinity\Legion\Cache");
                string baseURL = "http://192.168.1.6";
                string installURL = baseURL + "/game/install/legion/";
                //string dataURL = installURL + "data/";
                string WTF = installURL + "WTF/";

				DownloadURLCollection urls = new DownloadURLCollection();
				urls.Add(new DownloadURL(installURL + "Wow.exe", @"C:\Trinity\Legion\Wow.exe"));
				urls.Add(new DownloadURL(installURL + "Wow_Patched.exe", @"C:\Trinity\Legion\Wow_Patched.exe"));
                urls.Add(new DownloadURL(installURL + "tc_bundle.txt", @"C:\Trinity\Legion\tc_bundle.txt"));
                urls.Add(new DownloadURL(installURL + "Launcher.exe", @"C:\Trinity\Legion\Launcher.exe"));
                urls.Add(new DownloadURL(WTF + "Config.wtf", @"C:\Trinity\Legion\WTF\Config.wtf"));
                /*
                urls.Add(new DownloadURL(dataURL + "config/0a/c2/0ac24ebacb95e912378b17bd5fbafbda", @"C:\Trinity\Legion\data\config\0a\c2\0ac24ebacb95e912378b17bd5fbafbda"));
                urls.Add(new DownloadURL(dataURL + "config/5a/ce/5aceaf7900be8d43f102fefe1cb60111", @"C:\Trinity\Legion\data\config\\5a\\ce\\5aceaf7900be8d43f102fefe1cb60111"));
                urls.Add(new DownloadURL(dataURL + "config/5c/7e/5c7ea20a50fc69d7fc490796c14beab5", @"C:\Trinity\Legion\data\config\\5c\\7e\\5c7ea20a50fc69d7fc490796c14beab5"));
                urls.Add(new DownloadURL(dataURL + "config/29/a3/29a3283a6167c359aa21915e7a9fb859", @"C:\Trinity\Legion\data\config\\29\\a3\\29a3283a6167c359aa21915e7a9fb859"));
                // SHEM and Digit
                urls.Add(new DownloadURL(dataURL + "data/shmem", @"C:\Trinity\Legion\data\data\shmem"));
                urls.Add(new DownloadURL(dataURL + "data/data.001", @"C:\Trinity\Legion\data\data\data.001"));
                urls.Add(new DownloadURL(dataURL + "data/data.002", @"C:\Trinity\Legion\data\data\data.002"));
                urls.Add(new DownloadURL(dataURL + "data/data.003", @"C:\Trinity\Legion\data\data\data.003"));
                //IDX
                urls.Add(new DownloadURL(dataURL + "data/0a00000001.idx", @"C:\Trinity\Legion\data\data\0a00000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0a00000002.idx", @"C:\Trinity\Legion\data\data\0a00000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0a00000003.idx", @"C:\Trinity\Legion\data\data\0a00000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0a00000004.idx", @"C:\Trinity\Legion\data\data\0a00000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0b00000001.idx", @"C:\Trinity\Legion\data\data\0b00000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0b00000002.idx", @"C:\Trinity\Legion\data\data\0b00000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0b00000003.idx", @"C:\Trinity\Legion\data\data\0b00000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0b00000004.idx", @"C:\Trinity\Legion\data\data\0b00000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0c00000001.idx", @"C:\Trinity\Legion\data\data\0c00000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0c00000002.idx", @"C:\Trinity\Legion\data\data\0c00000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0c00000003.idx", @"C:\Trinity\Legion\data\data\0c00000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0c00000004.idx", @"C:\Trinity\Legion\data\data\0c00000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0d00000001.idx", @"C:\Trinity\Legion\data\data\0d00000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0d00000002.idx", @"C:\Trinity\Legion\data\data\0d00000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0d00000003.idx", @"C:\Trinity\Legion\data\data\0d00000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0d00000004.idx", @"C:\Trinity\Legion\data\data\0d00000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0d00000005.idx", @"C:\Trinity\Legion\data\data\0d00000005.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0e00000001.idx", @"C:\Trinity\Legion\data\data\0e00000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0e00000002.idx", @"C:\Trinity\Legion\data\data\0e00000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0e00000003.idx", @"C:\Trinity\Legion\data\data\0e00000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0e00000004.idx", @"C:\Trinity\Legion\data\data\0e00000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0f00000001.idx", @"C:\Trinity\Legion\data\data\0f00000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0f00000002.idx", @"C:\Trinity\Legion\data\data\0f00000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0f00000003.idx", @"C:\Trinity\Legion\data\data\0f00000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0f00000004.idx", @"C:\Trinity\Legion\data\data\0f00000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0000000001.idx", @"C:\Trinity\Legion\data\data\0000000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0000000002.idx", @"C:\Trinity\Legion\data\data\0000000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0000000003.idx", @"C:\Trinity\Legion\data\data\0000000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0000000004.idx", @"C:\Trinity\Legion\data\data\0000000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0100000001.idx", @"C:\Trinity\Legion\data\data\0100000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0100000002.idx", @"C:\Trinity\Legion\data\data\0100000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0100000003.idx", @"C:\Trinity\Legion\data\data\0100000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0100000004.idx", @"C:\Trinity\Legion\data\data\0100000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0200000001.idx", @"C:\Trinity\Legion\data\data\0200000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0200000002.idx", @"C:\Trinity\Legion\data\data\0200000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0200000003.idx", @"C:\Trinity\Legion\data\data\0200000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0200000004.idx", @"C:\Trinity\Legion\data\data\0200000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0300000001.idx", @"C:\Trinity\Legion\data\data\0300000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0300000002.idx", @"C:\Trinity\Legion\data\data\0300000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0300000003.idx", @"C:\Trinity\Legion\data\data\0300000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0300000004.idx", @"C:\Trinity\Legion\data\data\0300000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0400000001.idx", @"C:\Trinity\Legion\data\data\0400000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0400000002.idx", @"C:\Trinity\Legion\data\data\0400000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0400000003.idx", @"C:\Trinity\Legion\data\data\0400000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0400000004.idx", @"C:\Trinity\Legion\data\data\0400000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0500000001.idx", @"C:\Trinity\Legion\data\data\0500000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0500000002.idx", @"C:\Trinity\Legion\data\data\0500000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0500000003.idx", @"C:\Trinity\Legion\data\data\0500000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0500000004.idx", @"C:\Trinity\Legion\data\data\0500000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0500000005.idx", @"C:\Trinity\Legion\data\data\0500000005.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0600000001.idx", @"C:\Trinity\Legion\data\data\0600000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0600000002.idx", @"C:\Trinity\Legion\data\data\0600000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0600000003.idx", @"C:\Trinity\Legion\data\data\0600000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0600000004.idx", @"C:\Trinity\Legion\data\data\0600000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0700000001.idx", @"C:\Trinity\Legion\data\data\0700000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0700000002.idx", @"C:\Trinity\Legion\data\data\0700000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0700000003.idx", @"C:\Trinity\Legion\data\data\0700000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0700000004.idx", @"C:\Trinity\Legion\data\data\0700000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0800000001.idx", @"C:\Trinity\Legion\data\data\0800000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0800000002.idx", @"C:\Trinity\Legion\data\data\0800000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0800000003.idx", @"C:\Trinity\Legion\data\data\0800000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0800000004.idx", @"C:\Trinity\Legion\data\data\0800000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0900000001.idx", @"C:\Trinity\Legion\data\data\0900000001.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0900000002.idx", @"C:\Trinity\Legion\data\data\0900000002.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0900000003.idx", @"C:\Trinity\Legion\data\data\0900000003.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0900000004.idx", @"C:\Trinity\Legion\data\data\0900000004.idx"));
                urls.Add(new DownloadURL(dataURL + "data/0900000005.idx", @"C:\Trinity\Legion\data\data\0900000005.idx"));

                // Indices
                urls.Add(new DownloadURL(dataURL + "indices/00c79a72a9c5a32ab942a77e86da3e03.index", @"C:\Trinity\Legion\data\indices\00c79a72a9c5a32ab942a77e86da3e03.index"));
                urls.Add(new DownloadURL(dataURL + "indices/0b453fa2c5e7d6021980271ed9974e0e.index", @"C:\Trinity\Legion\data\indices\0b453fa2c5e7d6021980271ed9974e0e.index"));
                */

                FileDownloaderForm downloader = new FileDownloaderForm(urls);
				downloader.ShowDialog();
			}
			catch(Exception ex)
			{
				ExceptionManager.Publish(ex);
			}
		}
	}
}
