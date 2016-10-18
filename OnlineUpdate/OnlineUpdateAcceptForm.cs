
using System;
using System.Windows.Forms;

namespace OnlineUpdate
{
    internal partial class OnlineUpdateAcceptForm : Form
    {
        private OnlineUpdatable applicationInfo;

        private OnlineUpdateXML updateInfo;

        private OnlineUpdateInfoForm UpdateInfoForm;



        public OnlineUpdateAcceptForm(OnlineUpdatable applicationInfo,OnlineUpdateXML updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = this.applicationInfo.ApplicationName + " - Update Available";

            if (this.applicationInfo.ApplicationIcon != null)
            {
                this.Icon = this.applicationInfo.ApplicationIcon;
            }

            this.labelNewVersion.Text = string.Format("New Version: {0}", this.updateInfo.Version.ToString());
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void detailsbutton_Click(object sender, EventArgs e)
        {
            if (this.UpdateInfoForm == null)
                this.UpdateInfoForm = new OnlineUpdateInfoForm(this.applicationInfo, this.updateInfo);

            this.UpdateInfoForm.ShowDialog(this);
        }

    }
}
