using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace OnlineUpdate
{
    public partial class OnlineUpdateDownloadForm : Form
    {
        private WebClient webClient;

        private BackgroundWorker bgWorker;

        private string tempfile;

        private string md5;

        internal string TempFilePath
        { 
            get {return this.tempfile;}
        
        }

        internal OnlineUpdateDownloadForm(Uri location,string md5, Icon programIcon)
        {
            InitializeComponent();

            if(programIcon != null)
                   this.Icon = programIcon; 

            this.md5 = md5;

            webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DowmProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileComplete);

            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            try
            {
                webClient.DownloadFileAsync(location,this.tempfile);
            }
            catch 
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }

        }

private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
 	 this.DialogResult = (DialogResult)e.Result;
     this.Close();
}

private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
{
 	string file = ((string[])e.Argument)[0];
            string updateMD5 = ((string[])e.Argument)[1];

            if (Hasher.HashFile(file, HashType.md5).ToUpper() != updateMD5.ToUpper())
                e.Result = DialogResult.No;
            else
                e.Result = DialogResult.OK;
}

private void webClient_DownloadFileComplete(object sender, AsyncCompletedEventArgs e)
{
 	  if (e.Error != null)
         {
           this.DialogResult = DialogResult.No;     
           this.Close();
         }
      else if (e.Cancelled)  //
        {
          this.DialogResult = DialogResult.Abort;
          this.Close();
        }
      else
        {
          labelDownloadingProgressBar.Text = "verifying Download..";
          progressBar.Style = ProgressBarStyle.Marquee;

          bgWorker.RunWorkerAsync(new string[] { this.tempfile, this.md5 });
        }
}

private void webClient_DowmProgressChanged(object sender, DownloadProgressChangedEventArgs e)
{
 	this.labelDownloadingProgressBar.Text = string.Format("Downloaded {0} of {1}",FormatBytes(e.BytesReceived,1,true),FormatBytes(e.TotalBytesToReceive,1,true));
    this.progressBar.Value = e.ProgressPercentage;
}

        /// <summary>
        ///  great for any downloading application.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="decimalPlaces"></param>
        /// <param name="showBytesType"></param>
        /// <returns></returns>
private string FormatBytes(long bytes,int decimalPlaces,bool showBytesType)
{
    
            double newBytes = bytes;
            string formatString = "{0"; 
            string byteType = "B";  // first is Byte

            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";   // KB
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                newBytes /= 1073741824;
                byteType = "GB"; 
            }

            if (decimalPlaces > 0)
                formatString += ":0.";  // no decimals {0:0.

            for (int i = 0; i < decimalPlaces; i++) /// ADD how any decimals  
            {
                formatString += "0";
            }

            formatString += "}"; // close {0:0.}

            if (showBytesType)
                formatString += byteType; // {0:0.}B 

            return string.Format(formatString, newBytes);

}


    }
}
