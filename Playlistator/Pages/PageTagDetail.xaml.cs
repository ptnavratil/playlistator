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

using Playlistator.Model;
using System.Diagnostics;
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageTagDetail : Page
    {
        private Tag actualTag;

        public PageTagDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tag selectedTag = e.Parameter as Tag;
            actualTag = selectedTag;
            if (selectedTag != null)
            {
                textBlockTagName.Text = selectedTag.Name;
                textBlockTagDescription.Text = selectedTag.Description;
                textBlockTagCreated.Text = selectedTag.CreatedString;
            }
        }


        private async void buttonFlyoutDeleteTagConfirm_Click(object sender, RoutedEventArgs e)
        {
            Debug.Write("Delete song confirm flyout button clicked.");
            bool tagDeleted = DataAccess.DeleteTag(actualTag);
            if (tagDeleted)
            {
                flyoutConfirmTagDelete.Hide();
                Frame.Navigate(typeof(PageListTags));
                await new MessageDialog("Tag deleted.", "Tag deleted").ShowAsync();
            }

        }
    }
}
