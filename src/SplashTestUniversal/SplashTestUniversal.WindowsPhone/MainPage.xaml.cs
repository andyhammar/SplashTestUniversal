using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SplashTestUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            //force app to use full screen
            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);

            //Andreas Hammar 2014-10-06 15:09: code to wait while loading the image
            //var image = new BitmapImage();
            //var fileTask = StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/splash_jayway.png"));
            //var file = fileTask.GetAwaiter().GetResult();
            //var stream = file.OpenStreamForReadAsync().Result;
            //image.SetSource(stream.AsRandomAccessStream());
            //_image.Source = image;

            //this.Loaded += MainPage_Loaded;
            var timer = new DispatcherTimer() {Interval = TimeSpan.FromSeconds(5)};
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private async void TimerOnTick(object sender, object o)
        {
            ((DispatcherTimer)sender).Stop();

            var file = await ApplicationData.Current.LocalCacheFolder.GetFileAsync("file.txt");

            new MessageDialog(await FileIO.ReadTextAsync(file)).ShowAsync();

        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("loaded");
        }
    }
}
