using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class PageAddTag : Page
    {
        public PageAddTag()
        {
            this.InitializeComponent();
        }

        private async void buttonAddTag_Click(object sender, RoutedEventArgs e)
        {
            string tagName = textBoxTagName.Text.Trim();
            string tagDescription = textBoxTagDescription.Text.Trim();

            if (!string.IsNullOrEmpty(tagName))
            {
                bool tagInserted = DataAccess.InsertTag(tagName, tagDescription);
                if (tagInserted)
                {
                    await new MessageDialog("Tag successfully added.", "Tag creation").ShowAsync();
                }
            }
        }
    }
}
