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

            if (selectedItem.Equals(navigationViewItemHome))
            {
                frameMainContent.Navigate(typeof(PageHome));

            }
            else if (selectedItem.Equals(navigationViewItemPlayer))
            {
                //TEMP - test
                frameMainContent.Navigate(typeof(TempPage1));
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
