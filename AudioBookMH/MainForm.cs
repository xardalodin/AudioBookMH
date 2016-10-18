using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using PlayList;

namespace AudioBookMH
{
    public partial class MainForm : Form
    {
        // font for listview 
        FontStyleOptions font = new FontStyleOptions();


        public MainForm()
        {
            InitializeComponent();
        }
      

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            // create path if does not exists
            string path = "C:\\AudioBookPlayer_MH";
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(path);
            }

            NumberOfPlayLists file = new NumberOfPlayLists();
            listViewNames.Font = font.DefaultFont;

            if (File.Exists(file.Filename))
            {
                file = LoadXML.loadNumberOfPlaylist();
                populate(file);
            }
            else // if it does not exist create it 
            {
                saveXML.Savedata(file, file.Filename);
            } 
        }



        /// <summary>
        /// listview header font and borders 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewNames_DrawColumnHeader(Object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                using (var headerFont = new Font("Microsoft Sans Serif", 20, FontStyle.Bold))
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);
                }         
            }
        }


        private void NewButton_Click(object sender, EventArgs e)
        {
            
             NewAudioBook book = new NewAudioBook();
             book.UpdateAvailable += new EventHandler(playAudioBook_OnDataAvailable);
             book.Show();
              
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (listViewNames.SelectedItems.Count == 1)
            {
                int selectedrow = listViewNames.FocusedItem.Index;
                string filename = listViewNames.Items[selectedrow].Text;
                PlayAudioBook book = new PlayAudioBook(filename);
                book.OnDataAvailable += new EventHandler(playAudioBook_OnDataAvailable);
                book.Show();
            
            }
        }


        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            if (listViewNames.SelectedItems.Count == 1)
            {
                //delete from listview
                int selectedrow = listViewNames.FocusedItem.Index;
                string filename = listViewNames.Items[selectedrow].Text;
                listViewNames.Items[selectedrow].Remove();

                //delete from XMl file number of playlists 
                NumberOfPlayLists np1 = LoadXML.loadNumberOfPlaylist();
                np1.Delete(selectedrow);
                saveXML.Savedata(np1, np1.Filename);

                // Delete XML file playlist

                if (File.Exists("C:\\AudioBookPlayer_MH\\"+filename))
                {
                    File.Delete("C:\\AudioBookPlayer_MH\\"+filename);
                }

                else
                {
                    MessageBox.Show("could not find " + filename);
                
                }
            }

        }   

        void playAudioBook_OnDataAvailable(object sender, EventArgs e)
        {
            NumberOfPlayLists info = LoadXML.loadNumberOfPlaylist();
            populate(info);
        
        }

        private void populate(NumberOfPlayLists namesOfPlaylists)
        {
            List<List<string>> alotOfLists = new List<List<string>>();

            // add more in right order 
            alotOfLists.Add(namesOfPlaylists.NamesOfPlayList);
            alotOfLists.Add(namesOfPlaylists.CurrentTimeOfPlaylists);
            alotOfLists.Add(namesOfPlaylists.TempCurrentfilePlayingofAll);
            alotOfLists.Add(namesOfPlaylists.TempMaxNúmberOfFiles);

            List<ListViewItem> listviewCoulums = new List<ListViewItem>();

            int i = 0; // must exist a better way 
            foreach (string s in namesOfPlaylists.NamesOfPlayList)
            {
                ListViewItem temp = new ListViewItem(); // creates one for each playlist.
                temp.Font = font.DefaultFont;
                temp.Text = alotOfLists.ElementAt(0).ElementAt(i);
                temp.SubItems.Add(alotOfLists.ElementAt(1).ElementAt(i));
                temp.SubItems.Add(alotOfLists.ElementAt(2).ElementAt(i));
                temp.SubItems.Add(alotOfLists.ElementAt(3).ElementAt(i));
                listviewCoulums.Add(temp); // hoping temp gets deleted at some point.
                i++;
            
            }

            listViewNames.Items.Clear(); // remove old list 
            listViewNames.Items.AddRange(listviewCoulums.ToArray());
            System.GC.Collect(); // hoping to clear out all the ListViewItems 

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateForm form = new UpdateForm();
            form.Show();
        }

 



    }
}
