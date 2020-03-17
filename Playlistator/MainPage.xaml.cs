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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Playlistator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private SqliteConnection connection;

        private object temp;

        public MainPage()
        {
            this.InitializeComponent();
            //  this.connection = null;

            DataAccess.InitializeDatabase();

            Debug.WriteLine("Database initialized.", "INFO");
            Debug.WriteLine("Something", "WARNING");

            frameMainContent.Navigate(typeof(Page1));
        }

        private void buttonSQLiteTest1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"AppFolder={ApplicationData.Current.LocalFolder.Path}", "INFO");
        }

        private void buttonSQLiteTest2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
