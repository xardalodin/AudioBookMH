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
    public partial class NewAudioBook : Form
    {
        public event EventHandler UpdateAvailable;
        public NewAudioBook()
        {
            InitializeComponent();
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.ShowDialog();

            foreach (string s in open.FileNames)
            {
                addPlayList.Items.Add(s);                
            }
            addPlayList.SelectedIndex = addPlayList.SelectedIndex + 1;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FilePlayList savePlaylist = new FilePlayList();

            foreach (string s in addPlayList.Items)
            {
                savePlaylist.PlayList.Add(s);
            }
            savePlaylist.Onlynames();
            savePlaylist.CurrentTime = 0;
            savePlaylist.PlayListItemselected = addPlayList.SelectedIndex;

            string filename = textBoxName.Text + ".xml";
            savePlaylist.PlayListFile = filename;

            try
            {

                saveXML.Savedata(savePlaylist, "C:\\AudioBookPlayer_MH\\" + filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // load file containing the lists of playlist
            NumberOfPlayLists info = LoadXML.loadNumberOfPlaylist();

            info.NamesOfPlayList.Add(filename);
            info.CurrentTimeOfPlaylists.Add("00:00:00");
            info.TempMaxNúmberOfFiles.Add(addPlayList.Items.Count.ToString());
            info.TempCurrentfilePlayingofAll.Add((savePlaylist.PlayListItemselected + 1).ToString());

            saveXML.Savedata(info, info.Filename);

            UpdateAvailable(this, EventArgs.Empty);

            this.Close();

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
