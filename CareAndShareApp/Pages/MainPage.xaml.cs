using CareAndShareApp.ViewModels;
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

namespace CareAndShareApp.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Parse.ParseClient.Initialize("B5AwpqJBAbLqwGHrY1fC40eWkrmu0eiI7Z6LhUo4", "fzgFGrNnTopXsgz2JKmxUNy4af6e4u7gnozzecWB");
        }

        private void SubmitProblemClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LocationPage));
        }

        private void AboutTheAppButtonClick(object sender, RoutedEventArgs e)
        {
            this.tbAbout.Visibility = Visibility.Visible;
        }

        private void AppBarHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ListProblemsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListProblemsPage));
        }
    }
}
