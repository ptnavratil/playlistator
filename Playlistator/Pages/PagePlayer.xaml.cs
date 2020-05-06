using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Playlistator.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PagePlayer : Page
    {
        public PagePlayer()
        {
            this.InitializeComponent();
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
        }

        private void buttonShufflePlaylist_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonClearPlaylist_Click(object sender, RoutedEventArgs e)
        {
            listViewPlaylist.Items.Clear();
        }

        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
