using Playlistator.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TempPage1 : Page
    {
        private Windows.Storage.StorageFile selectedSongFile;
        private MediaElement player;

        public TempPage1()
        {
            this.InitializeComponent();
            player = new MediaElement();
            //player.AutoPlay = false;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PageAddTag));
        }

        private async void buttonSelectSong_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".wav");

            selectedSongFile = await picker.PickSingleFileAsync();
            if (selectedSongFile != null)
            {
                // Application now has read/write access to the picked file
                textBoxSelectedSong.Text = selectedSongFile.Path;
                //String path = "C:\\Users\\Venaca\\Music\\Písničky všechny\\Tancování\\10 letkiss---Letkiss.mp3";
               // Windows.Storage.StorageFile selectedSongFile = StorageFile.GetFileFromPathAsync(path).GetResults();
                var stream = await selectedSongFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                player.SetSource(stream, "");
            }
            else
            {
                textBoxSelectedSong.Text = "";
            }
        }

        private async void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            String path = "C:\\Users\\Venaca\\Music\\Písničky všechny\\Tancování\\10 letkiss---Letkiss.mp3";
            selectedSongFile = await StorageFile.GetFileFromPathAsync(path);
            var stream2 = await selectedSongFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            player.SetSource(stream2, "");

            if (selectedSongFile != null) {
                player.Play();
            }

        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSongFile != null)
            {
                player.Pause();
            }
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSongFile != null)
            {
                player.Stop();
            }
        }

        private async void buttonCheckFilePathIsValid_Click(object sender, RoutedEventArgs e)
        {
                FileInfo songFile = new FileInfo(textBoxSelectedSong.Text);
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
    }
}
