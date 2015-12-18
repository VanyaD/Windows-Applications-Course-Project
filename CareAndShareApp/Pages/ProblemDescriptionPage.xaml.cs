namespace CareAndShareApp.Pages
{
    using CareAndShareApp.ViewModels;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class ProblemDescriptionPage : Page
    {
        ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
        LocatorViewModel viewModel;

        public ProblemDescriptionPage()
        {
            this.InitializeComponent();

            fonts.Add(new FontFamily("Arial"));
            fonts.Add(new FontFamily("Courier New"));
            fonts.Add(new FontFamily("Times New Roman"));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = e.Parameter as LocatorViewModel;
        }

        private void AppBarHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }    
    }
}
