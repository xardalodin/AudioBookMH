using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace PlayList
{
    public class LoadXML
    {

        public static NumberOfPlayLists loadNumberOfPlaylist()
        {
            XmlSerializer xs = new XmlSerializer(typeof(NumberOfPlayLists));
            FileStream read = new FileStream("C:\\AudioBookPlayer_MH\\namesOFPlaylists.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            NumberOfPlayLists info = (NumberOfPlayLists)xs.Deserialize(read);
            read.Close();
            return info;
        }

        public static FilePlayList loadFileplaylist(string filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(FilePlayList));
            FileStream read = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            FilePlayList info = (FilePlayList)xs.Deserialize(read);
            read.Close();
            return info;
        }
    }
}
