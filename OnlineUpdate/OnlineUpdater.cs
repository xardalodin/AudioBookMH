using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OnlineUpdate
{
    public class OnlineUpdater
    {
        private OnlineUpdatable applicationInfo;

        private BackgroundWorker bgWorker;

        public OnlineUpdater(OnlineUpdatable applicationInfo)
        {
            this.applicationInfo = applicationInfo;

            this.bgWorker = new BackgroundWorker();

            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerComplete);
        
        }

        public void DoUpdate()
        {
            if (!this.bgWorker.IsBusy)
                this.bgWorker.RunWorkerAsync(this.applicationInfo);
        }

        private void bgWorker_DoWork(object sender,DoWorkEventArgs e)
        {
            OnlineUpdatable applicatiion = (OnlineUpdatable)e.Argument;

            if (!OnlineUpdateXML.ExistsOnServer(applicatiion.UpdateXmlLocation)) //check if file exists on server
            {
                e.Cancel = true;
            }
            else
            {
                e.Result = OnlineUpdateXML.Parse(applicatiion.UpdateXmlLocation, applicatiion.ApplicationID);
            }
        
        }

        private void bgWorker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                OnlineUpdateXML update = (OnlineUpdateXML)e.Result;

                if (update != null && update.IsVersionNewerThanOld(this.applicationInfo.ApplicationAssembley.GetName().Version))
                {
                    if (new OnlineUpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.context)
                        == DialogResult.Yes)
                        this.DownloadUpdate(update);

                }
                else
                    MessageBox.Show("You have the latest update!");

            }
            else
                MessageBox.Show("No update information was found!");
        }

        private void DownloadUpdate(OnlineUpdateXML update)
        {
            OnlineUpdateDownloadForm form = new OnlineUpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.context);

            if (result == DialogResult.OK)
            {
                string currentPath = this.applicationInfo.ApplicationAssembley.Location;
                string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;
 
                //install it
                updateApplication(form.TempFilePath, currentPath, newPath, update.LaunchArgs);
                Application.Exit();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("update cancelled... WHY!!!", "update cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update Error: The lemmings are not running", "update download error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateApplication(string tempFilePath, string currentPath, string newPath, string launchArgs)
        {

            /*  Choice /C Y /N /D Y /t 4  = program off pause 4 seconds 
           *  Del /F /Q \"{0}\" =  deletes original file 
           *  Choice /C Y /N /D Y /t 2  = pause for 2 sec
           *   Move /Y \"{1}\" \"{2}\" = moves downloaded update file into position 
           *   Start \"\" /D \"{3}\" \"{4}\" {5} = starts with launchArgs 
           */
            string arguments = "/C Choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & Choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";


            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = string.Format(arguments, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.FileName = "cmd.exe";
            Process.Start(info);

        }

 
        



    }
}
