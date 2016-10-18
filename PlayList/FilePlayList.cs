/*
 * name Mikael Hurtig 
 * a class to save in a XML file, for playlists  
 *  playlist = the URL to the file 
 *  playlisttfile(metadata) = the name of the XML file.
 *  current time = where your currently at in the playlist , saved when you close Playaudiobook form. 
 *  playlistitemSelected = if there are several files to the audiobook , stores the one that is playing.
 *  
 *  to do:
 *  add a virsion of playlist with only the files names , not complute URL.   DONE
 *
 * rebuilding inside a class library 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayList
{
    public class FilePlayList
    {
        // Playlist 
        private List<string> playlist = new List<string>();
        private List<string> onlyNamePlaylist = new List<string>();

        // Meta data about playlist
        private string playListFile;
        private double curentTime;
        private int playListItemSelected;

        /// <summary>
        /// croping away file path and keaping only name. 
        /// </summary>
        public List<string> OnlyNamePlayList
        {
        get {return onlyNamePlaylist;}
        }
        /// <summary>
        /// the XML FILE
        /// </summary>
        public string PlayListFile
        {
            get { return playListFile; }
            set { playListFile = value; }
        }
        /// <summary>
        /// the XML file that contains all the audio files for the playlist 
        /// </summary>
        public List<string> PlayList
        {
            get { return playlist; }
            set { playlist = value;}        
        }
        /// <summary>
        /// current elapsed time of the selected item 
        /// </summary>
        public Double CurrentTime
        { 
            get{ return curentTime;}
            set { curentTime = value; }
        }

        public int PlayListItemselected
        {
            get { return playListItemSelected; }
            set { playListItemSelected = value; }
        
        }

        public void Onlynames()
        {
            foreach (string s in playlist)
            {
                onlyNamePlaylist.Add(Path.GetFileName(s));
            }
        
        }



    }
}
