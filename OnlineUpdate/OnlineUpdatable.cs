using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace OnlineUpdate
{
    public interface OnlineUpdatable
    {
        string ApplicationName { get; }

        string ApplicationID { get; }

        Assembly ApplicationAssembley { get; }

        Icon ApplicationIcon { get; }

        Uri UpdateXmlLocation { get; }

        Form context { get; }


    }
}
