using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using PlayList;

namespace AudioBookMH
{
    public partial class PlayAudioBook : Form
    {
        public event EventHandler OnDataAvailable;

        private string filename;

        FilePlayList playlist;


        public PlayAudioBook(string incomingFilename)
        {
            filename = incomingFilename;
            try
            {
                playlist = LoadXML.loadFileplaylist("C:\\AudioBookPlayer_MH\\" + filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + filename + " " +ex);
            }
            InitializeComponent();
        }

        private void PlayAudioBook_Load_1(object sender, EventArgs e)
        {
            listBoxPlayList.Items.Clear();

            foreach (string s in playlist.OnlyNamePlayList)
            {
                listBoxPlayList.Items.Add(s);
            }

            listBoxPlayList.SelectedIndex = playlist.PlayListItemselected;
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = playlist.CurrentTime;
            axWindowsMediaPlayer1.URL = playlist.PlayList.ElementAt(playlist.PlayListItemselected);
            timer1.Start(); // 3000 to jump to next file.
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Closed();
                OnDataAvailable(this, EventArgs.Empty);
            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                Closed();
            }
        }

        private void Closed()
        {
            playlist.CurrentTime = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            playlist.PlayListItemselected = listBoxPlayList.SelectedIndex;

            saveXML.Savedata(playlist, "C:\\AudioBookPlayer_MH\\" + filename);

            NumberOfPlayLists savetime = LoadXML.loadNumberOfPlaylist();
            int position = savetime.NamesOfPlayList.IndexOf(filename);
            
            savetime.CurrentTimeOfPlaylists.Insert(position, axWindowsMediaPlayer1.Ctlcontrols.currentPositionString);  // insert new time
            
            savetime.CurrentTimeOfPlaylists.RemoveAt(position + 1); // remove old time
            
            savetime.TempCurrentfilePlayingofAll.Insert(position, (listBoxPlayList.SelectedIndex + 1).ToString());  // insert new selected file
            
            savetime.TempCurrentfilePlayingofAll.RemoveAt(position + 1); // remove old selected file.
            
            saveXML.Savedata(savetime, savetime.Filename);
            timer1.Stop();


        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timer1.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            timer1.Stop();
        }

     

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                // if just played last file then true 
                if ((listBoxPlayList.Items.Count - 1) == listBoxPlayList.SelectedIndex)
                {
                    listBoxPlayList.SelectedIndex = 0;
                    timer1.Stop();
                }
                else
                {
                    int itemNumb = listBoxPlayList.SelectedIndex;
                    listBoxPlayList.SelectedIndex = itemNumb + 1;
                    axWindowsMediaPlayer1.URL = playlist.PlayList.ElementAt(listBoxPlayList.SelectedIndex);
                    timer1.Start();
                }
            }
            else
            {
                timer1.Start();
            }

        }

 

    }
}
