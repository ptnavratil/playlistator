using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Playlistator.Model;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playlistator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageListTags : Page
    {
        public PageListTags()
        {
            this.InitializeComponent();

            listViewTags.ItemsSource = DataAccess.SelectAllTags();
        }

        private void buttonGoToSelectedTagDetail_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = listViewTags.SelectedItem;
            if (selectedItem != null && selectedItem is Tag)
            {
                Tag selectedTag = selectedItem as Tag;
                this.Frame.Navigate(typeof(PageTagDetail), selectedTag);
            }
        }
    }
}
