/*
   name: mikael Hurtig 
 *  class to save in a XML file to store 
 *  ínformation about playlists fro audiobook files
 *  namesOfPlayList = the URL to the XML files for each playlist
 *  CurrentTimeOfPlayLists = how long you have lisend to the current file.
 *  
 * todo: 
 *  add more information.
 *  the exact file your currently lissening to in the playlist
 *  add a column to the listview in form1 (rename form1) to display file currently playing 
 *  
 * note:
 * why I dident call it ListOfPlaylists I will never know
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayList
{
   public  class NumberOfPlayLists
    {
        private List<string> namesOfPlayList = new List<string>();
        private List<string> currentTimeOfPlaylists = new List<string>();
        private List<string> currentFilePlayingOfAll = new List<string>();

        private List<string> tempCurrentfilePlayingofAll = new List<string>();
        private List<string> tempMaxNúmberOfFiles = new List<string>();

        private string filename = "C:\\AudioBookPlayer_MH\\namesOFPlaylists.xml"; // hope gets read righs

        public string Filename
        {
            get { return filename; }
        }

        public List<string> TempCurrentfilePlayingofAll
        {
            get { return tempCurrentfilePlayingofAll; }
            set { tempCurrentfilePlayingofAll = value; }

        }

        public List<string> TempMaxNúmberOfFiles
        {
            get { return tempMaxNúmberOfFiles; }
            set { tempMaxNúmberOfFiles = value; }
        }

        public List<string> NamesOfPlayList
        {
            get { return namesOfPlayList; }
            set { namesOfPlayList = value; }
        }

        public List<string> CurrentTimeOfPlaylists
        {
            get { return currentTimeOfPlaylists; }
            set { currentTimeOfPlaylists = value; }

        }

        public static List<string> StringCalculations(List<int> listInt)
        {
            List<string> listString = new List<string>();
            foreach (int s in listInt)
            {
                listString.Add(s.ToString());
            }
            return listString;
        }

        public void Delete(int row) 
        {
            namesOfPlayList.RemoveAt(row);
            currentTimeOfPlaylists.RemoveAt(row);
            tempCurrentfilePlayingofAll.RemoveAt(row);
            tempMaxNúmberOfFiles.RemoveAt(row);
        }

    }
}
