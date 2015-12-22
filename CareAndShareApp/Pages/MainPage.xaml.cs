namespace CareAndShareApp.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

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
            if (this.tbAbout.Visibility == Visibility.Visible)
            {
                this.tbAbout.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.tbAbout.Visibility = Visibility.Visible;
            }
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
