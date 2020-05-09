using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Playlistator.Model;
using System;
using Windows.Storage;
using System.Diagnostics;
using Windows.UI.Xaml.Documents;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PagePlayer : Page
    {
        private Windows.Storage.StorageFile selectedSongFile;
        private int actualPlaingSongIndex = 0;
        private bool shuflePlaing = false;
        private Random random = new Random();
        public PagePlayer()
        {
            this.InitializeComponent();
            player.AutoPlay = false;
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IList<Tag> listOfAllTags = DataAccess.SelectAllTags();
            comboBoxTagToAdd.ItemsSource = listOfAllTags;
        }

        private void buttonAddSongsWithTag_Click(object sender, RoutedEventArgs e)
        {
            Tag selectedTag = comboBoxTagToAdd.SelectedItem as Tag;
            if (selectedTag != null)
            {
                IList<Song> songsWithTag = DataAccess.SelectAllSongsWithSpecifiedTag(selectedTag);

                ItemCollection actualItems = listViewPlaylist.Items;
                foreach (var oneSong in songsWithTag)
                {
                    actualItems.Add(oneSong);
                }

            }

            if (selectedSongFile == null && listViewPlaylist.Items.Count != 0) {
                listViewPlaylist.SelectedIndex = 0;
                playerSetSong();
            }

        }

        private void buttonShufflePlaylist_Click(object sender, RoutedEventArgs e)
        {
            shuflePlaing = !shuflePlaing;
        }

        private void buttonClearPlaylist_Click(object sender, RoutedEventArgs e)
        {
            listViewPlaylist.Items.Clear();
            player.Stop();
            player.AutoPlay = false;
            selectedSongFile = null;
            textBlockSongName.Text = "";
            textBlockSongAuthor.Text = "";
        }

        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPlaylist.Items.Count == 0) {
                return;
            }

            if (shuflePlaing)
            {
                int index = random.Next(listViewPlaylist.Items.Count);
                while (actualPlaingSongIndex == index && listViewPlaylist.Items.Count != 1) {
                    index = random.Next(listViewPlaylist.Items.Count);
                }
                listViewPlaylist.SelectedIndex = index;
            }
            else {
                listViewPlaylist.SelectedIndex = (listViewPlaylist.SelectedIndex - 1) % listViewPlaylist.Items.Count;
                if (listViewPlaylist.SelectedIndex < 0)
                {
                    listViewPlaylist.SelectedIndex = listViewPlaylist.Items.Count - 1;
                }
            }

            
            actualPlaingSongIndex = listViewPlaylist.SelectedIndex;
            playerSetSong();
            player.Play();

        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSongFile != null)
            {
                if (actualPlaingSongIndex != listViewPlaylist.SelectedIndex)
                {
                    playerSetSong();
                    actualPlaingSongIndex = listViewPlaylist.SelectedIndex;
                }
                player.AutoPlay = true;
                player.Play();
            }

        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSongFile != null)
            {
                player.Pause();
                player.AutoPlay = false;
            }

        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSongFile != null)
            {
                player.Stop();
                player.AutoPlay = false;
            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPlaylist.Items.Count == 0)
            {
                return;
            }


            if (shuflePlaing)
            {
                int index = random.Next(listViewPlaylist.Items.Count);
                while (actualPlaingSongIndex == index && listViewPlaylist.Items.Count != 1)
                {
                    index = random.Next(listViewPlaylist.Items.Count);
                }
                listViewPlaylist.SelectedIndex = index;
            }
            else
            {
                listViewPlaylist.SelectedIndex = (listViewPlaylist.SelectedIndex + 1) % listViewPlaylist.Items.Count;  
            }

            actualPlaingSongIndex = listViewPlaylist.SelectedIndex;
            playerSetSong();
            player.Play();
        }

        private async void playerSetSong() {
            int index = listViewPlaylist.SelectedIndex;
            if (index >= listViewPlaylist.Items.Count  || index == -1)
            {
                return;
            }
            Song song = (Song)listViewPlaylist.Items[index];
            String path = song.FilesystemPath;
            selectedSongFile = await StorageFile.GetFileFromPathAsync(path);
            var stream = await selectedSongFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            player.SetSource(stream, "");
            textBlockSongName.Text = song.SongName;
            textBlockSongAuthor.Text = song.AuthorName;
        }
    }
}
