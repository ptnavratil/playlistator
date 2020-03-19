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
using Windows.Storage;

using System.Diagnostics;
using Playlistator.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private SqliteConnection connection;

        public MainPage()
        {
            this.InitializeComponent();
            //  this.connection = null;

            DataAccess.InitializeDatabase();

            Debug.WriteLine("Database initialized.", "INFO");
            Debug.WriteLine("Something", "WARNING");

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

            if (selectedItem.Equals(navigationViewItemHome))
            {
                frameMainContent.Navigate(typeof(PageHome));

            }
            else if (selectedItem.Equals(navigationViewItemPlayer))
            {
                Debug.WriteLine("Page PLAYER selected", "INFO");
            }
            else if (selectedItem.Equals(navigationViewItemAddTag))
            {
                Debug.WriteLine("'PageAddTag' selected", "INFO");
                frameMainContent.Navigate(typeof(PageAddTag));
            }
            else if (selectedItem.Equals(navigationViewItemListTags))
            {
                Debug.WriteLine("'PageListTags' selected", "INFO");
                frameMainContent.Navigate(typeof(PageListTags));
            }
            else if (selectedItem.Equals(navigationViewItemAddSong))
            {
                Debug.WriteLine("'PageAddSong' selected", "INFO");
                frameMainContent.Navigate(typeof(PageAddSong));
            }
            else if (selectedItem.Equals(navigationViewItemListSongs))
            {
                Debug.WriteLine("Page LIST SONGS selected", "INFO");
            }
        }
    }
}
