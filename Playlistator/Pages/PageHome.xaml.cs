using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
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
    public sealed partial class PageHome : Page
    {
        public PageHome()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(@"C:\");
            }
            catch
            {
                MessageDialog dlg = new MessageDialog(
                    "It seems you have not granted permission for this app to access the file system broadly. " +
                    "Without this permission, the app cannot work correctly. " +
                    "You can grant this permission in the Settings app, if you wish. You can do this now or later. " +
                    "If you change the setting while this app is running, it will terminate the app so that the " +
                    "setting can be applied. Do you want to do this now?",
                    "File system permissions");
                dlg.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(InitMessageDialogHandler), 0));
                dlg.Commands.Add(new UICommand("No", new UICommandInvokedHandler(InitMessageDialogHandler), 1));
                dlg.DefaultCommandIndex = 0;
                dlg.CancelCommandIndex = 1;
                await dlg.ShowAsync();
            }
        }

        private async void InitMessageDialogHandler(IUICommand command)
        {
            if ((int)command.Id == 0)
            {
                await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-broadfilesystemaccess"));
            }
        }

    }


}
