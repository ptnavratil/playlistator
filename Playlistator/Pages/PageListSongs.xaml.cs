using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Diagnostics;
using Playlistator.Model;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageListSongs : Page
    {
        public PageListSongs()
        {
            this.InitializeComponent();
            listViewSongs.ItemsSource = DataAccess.SelectAllSongs();
        }

        private void buttonGoToSelectedSongDetail_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = listViewSongs.SelectedItem;
            if (selectedItem != null && selectedItem is Song) {
                Song selectedSong = selectedItem as Song;
                Debug.WriteLine($"{selectedItem?.GetType().ToString()}", "DEBUG");

                this.Frame.Navigate(typeof(PageSongDetail), selectedSong);


            }
        
        }
    }
}
