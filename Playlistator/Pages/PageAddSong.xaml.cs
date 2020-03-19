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
    public sealed partial class PageAddSong : Page
    {
        private Windows.Storage.StorageFile selectedSongFile;

        public PageAddSong()
        {
            this.InitializeComponent();
        }

        private async void buttonAddSong_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("buttonAddSong_Click", "DEBUG");

            string songName = textBoxSongName.Text.Trim();
            string authorName = textBoxAuthorName.Text.Trim();
            string filesystemPath = textBoxFilesystemPath.Text;

            if (!string.IsNullOrEmpty(songName) && !string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(filesystemPath))
            {
                bool songInserted = DataAccess.InsertSong(new Song() { SongName = songName, AuthorName = authorName, FilesystemPath = filesystemPath });
                if (songInserted)
                {
                    await new MessageDialog("Song successfully added.", "Song creation").ShowAsync();
                }
            }

        }

        private async void buttonSelectFilesystemPath_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            
            Utils.AllowedFileTypes.ToList().ForEach(ft => { picker.FileTypeFilter.Add(ft); });

            selectedSongFile = await picker.PickSingleFileAsync();
            if (selectedSongFile != null)
            {
                Debug.WriteLine($"Filesystem path={selectedSongFile.Path}", "DEBUG");
                textBoxFilesystemPath.Text = selectedSongFile.Path;
            }
            else
            {
                //textBoxSelectedSong.Text = "";
            }

        }
    }
}
