using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using System.Diagnostics;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Playlistator.Model;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageSongDetail : Page
    {

        private Song actualSong;
        private IList<Tag> listOfTagsToAdd;
        private IList<Tag> listOfTagsToRemove;

        public PageSongDetail()
        {
            this.InitializeComponent();
            listOfTagsToAdd = new List<Tag>();
            listOfTagsToRemove = new List<Tag>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Song selectedSong = e.Parameter as Song;
            actualSong = selectedSong;
            if (selectedSong != null)
            {
                textBlockSongName.Text = selectedSong.SongName;
                textBlockAuthorName.Text = selectedSong.AuthorName;
                textBlockFilesystemPath.Text = selectedSong.FilesystemPath;
                //FIXME naplneni comboboxu

                IList<long> listOfSongTagIds = DataAccess.SelectAllIdsOfSelectedSongTags(selectedSong);
                IList<Tag> listOfAllTags = DataAccess.SelectAllTags();

                //IList<Tag> listOfTagsToAdd = new List<Tag>();
                //IList<Tag> listOfTagsToRemove = new List<Tag>();

                foreach (Tag oneTag in listOfAllTags)
                {
                    if (listOfSongTagIds.Contains(oneTag.Id))
                    {
                        listOfTagsToRemove.Add(oneTag);
                    }
                    else
                    {
                        listOfTagsToAdd.Add(oneTag);
                    }
                }
                /*
                FileInfo Exists() returns false when file exists
                UWP access to the path is denied
                 */

                comboBoxTagsToAdd.ItemsSource = listOfTagsToAdd;
                comboBoxTagsToRemove.ItemsSource = listOfTagsToRemove;
            }
        }

        private async void buttonCheckFilePath_Click(object sender, RoutedEventArgs e)
        {
            //FIXME nefunkcni - problem s opravnenimi v FileInfo.Exists()
            Debug.WriteLine($"actualSong.FSPath={actualSong.FilesystemPath}", "DEBUG");
            FileInfo songFile = new FileInfo(actualSong.FilesystemPath);
            bool songFileExists = songFile.Exists;
            if (songFileExists)
            {
                await new MessageDialog("Path to song file is valid.", "Song file path check").ShowAsync();
            }
            else
            {
                await new MessageDialog("Path to song file is invalid.", "Song file path check").ShowAsync();
            }
        }

        private void buttonAddTag_Click(object sender, RoutedEventArgs e)
        {
            Tag selectedTag = comboBoxTagsToAdd.SelectedItem as Tag;
            if (selectedTag != null)
            {
                bool tagAdded = DataAccess.AddTagToSong(actualSong, selectedTag);
                if (tagAdded)
                {
                    listOfTagsToAdd.Remove(selectedTag);
                    comboBoxTagsToAdd.SelectedItem = null;
                    listOfTagsToRemove.Add(selectedTag);

                    //comboBoxTagsToAdd.Items.Remove(selectedTag);
                    //comboBoxTagsToRemove.Items.Add(selectedTag);
                    Debug.WriteLine($"Tag[{selectedTag.Name}] added to song.", "DEBUG");
                }
            }
        }

        private void buttonRemoveTag_Click(object sender, RoutedEventArgs e)
        {
            Tag selectedTag = comboBoxTagsToRemove.SelectedItem as Tag;
            if (selectedTag != null)
            {
                bool tagRemoved = DataAccess.RemoveTagFromSong(actualSong, selectedTag);
                if (tagRemoved)
                {
                    listOfTagsToRemove.Remove(selectedTag);
                    comboBoxTagsToRemove.SelectedItem = null;
                    listOfTagsToAdd.Add(selectedTag);

                    //comboBoxTagsToRemove.Items.Remove(selectedTag);
                    //comboBoxTagsToAdd.Items.Add(selectedTag);
                    Debug.WriteLine($"Tag[{selectedTag.Name}] removed from song.", "DEBUG");
                }
            }
        }
    }
}
