using Windows.UI.Xaml.Controls;

using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            DataAccess.InitializeDatabase();
            Debug.WriteLine("Database initialized.", "DEBUG");
            frameMainContent.Navigate(typeof(PageHome));
        }

        private void navigationViewMainNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            NavigationViewItemBase container = args.SelectedItemContainer;
            NavigationViewItem selectedItem;
            if (container is NavigationViewItem)
            {
                selectedItem = container as NavigationViewItem;
            }
            else
            {
                return;
            }

            if (selectedItem.Equals(navigationViewItemHome) || selectedItem.Equals(navigationViewItemAboutApplication))
            {
                frameMainContent.Navigate(typeof(PageHome));

            }
            else if (selectedItem.Equals(navigationViewItemPlayer))
            {
                frameMainContent.Navigate(typeof(PagePlayer));
            }
            else if (selectedItem.Equals(navigationViewItemAddTag))
            {
                frameMainContent.Navigate(typeof(PageAddTag));
            }
            else if (selectedItem.Equals(navigationViewItemListTags))
            {
                frameMainContent.Navigate(typeof(PageListTags));
            }
            else if (selectedItem.Equals(navigationViewItemAddSong))
            {
                frameMainContent.Navigate(typeof(PageAddSong));
            }
            else if (selectedItem.Equals(navigationViewItemListSongs))
            {
                frameMainContent.Navigate(typeof(PageListSongs));
            }
        }
    }
}
