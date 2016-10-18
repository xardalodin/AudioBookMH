using System;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace OnlineUpdate
{
    public class OnlineUpdateXML
    {
        private Version version;
        private Uri uri;
        private string filename;
        private string md5;
        private string description;
        private string launchArgs;

        internal Version Version
        {
            get { return this.version; }
        }

        internal Uri Uri
        {
            get { return this.uri; }
        }

        internal string FileName
        {
            get { return this.filename; }
        }

        internal string MD5
        {
            get { return this.md5; }
        }

        internal string Description
        {
            get { return this.description; }
        }
        internal string LaunchArgs
        {
            get { return this.launchArgs; }
        }
        /// <summary>
        /// Constructor of XML file 
        /// </summary>
        /// <param name="version"></param>
        /// <param name="uri"></param>
        /// <param name="filename"></param>
        /// <param name="md5"></param>
        /// <param name="description"></param>
        /// <param name="launchArgs"></param>
        internal OnlineUpdateXML(Version version, Uri uri, string filename, string md5, string description, string launchArgs)
        { 
            this.version = version;
            this.uri = uri;
            this.filename = filename;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        /// <summary>
        /// check location exists, includes that the file is there I think
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);  // create a web request from location
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();  // get response
                response.Close();

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch { return false; }    
        
        }

        /// <summary>
        /// check if version number of program is newer than current version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        internal bool IsVersionNewerThanOld(Version version)
        {
            return this.version > version;
        }

        /// <summary>
        /// certificate = true
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="appID"></param>
        /// <returns></returns>
        internal static OnlineUpdateXML Parse(Uri location, string appID)
        {
            Version version = null;
            string url = "",
                filename = "",
                md5 = "", 
                description = "", 
                launchArgs = "";

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (s, ce, ch, ss1) => true;
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                XmlNode updateNode = doc.DocumentElement.SelectSingleNode("//update[@appID='" + appID + "']");

                if (updateNode == null) // nothing in node appID NOTE SPELLING
                    return null;

                version = Version.Parse(updateNode["version"].InnerText);
                url = updateNode["url"].InnerText;
                filename = updateNode["fileName"].InnerText;
                md5 = updateNode["md5"].InnerText;
                description = updateNode["description"].InnerText;
                launchArgs = updateNode["launchArgs"].InnerText;

                return new OnlineUpdateXML(version, new Uri(url), filename, md5, description, launchArgs);


            }
            catch 
            {
                return null;
            }

        }







    }

}
