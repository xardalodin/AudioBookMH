using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineUpdate;

namespace AudioBookMH
{
    public partial class UpdateForm : Form, OnlineUpdatable
    {
        private OnlineUpdater updater;
        public UpdateForm()
        {
            InitializeComponent();
            this.labelUpdate2.Text = this.ApplicationAssembley.GetName().Version.ToString();
            updater = new OnlineUpdater(this);
        }

        private void updateButton2_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }
        public string ApplicationName
        {
            get { return "AudioBookMH"; }
        }

        public string ApplicationID
        {
            get { return "AudioBookMh"; }
        }

        public Assembly ApplicationAssembley
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("http://localhost:8182/update.xml"); } // change to server.
        }

        public Form context
        {
            get { return this; }
        }
    }
}
