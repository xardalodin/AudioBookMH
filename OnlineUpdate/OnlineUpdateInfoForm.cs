using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineUpdate
{
    internal partial class OnlineUpdateInfoForm : Form
    {
        public OnlineUpdateInfoForm(OnlineUpdatable applicationInfo,OnlineUpdateXML updateInfo)
        {
            InitializeComponent();

            if (applicationInfo.ApplicationIcon == null)
                this.Icon = applicationInfo.ApplicationIcon;

            this.Text = applicationInfo.ApplicationName + " - Update Info";
            this.labelverssions.Text = string.Format("Current Version: {0}\nUpdate Version: {1}",
            applicationInfo.ApplicationAssembley.GetName().Version.ToString(),
            updateInfo.Version.ToString());
            this.richTextBoxDescription.Text = updateInfo.Description;

        }

        private void OnlineUpdateInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            //only allow ctrl c to copy in textbox
            if (!(e.Control && e.KeyCode == Keys.C))
                e.SuppressKeyPress = true;
        }

    }
}
