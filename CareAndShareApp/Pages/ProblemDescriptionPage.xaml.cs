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
        //ObservableCollection<CategoryViewModel> categories = new ObservableCollection<CategoryViewModel>();
        LocatorViewModel viewModel;

        public ProblemDescriptionPage()
        {
            this.InitializeComponent();
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
