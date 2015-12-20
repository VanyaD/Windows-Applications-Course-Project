namespace CareAndShareApp.Pages
{
    using CareAndShareApp.ViewModels;
    using Parse;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class ProblemDescriptionPage : Page
    {
        //ObservableCollection<CategoryViewModel> categories = new ObservableCollection<CategoryViewModel>();
        LocatorViewModel viewModel;
        ParseObject parseObject;

        public ProblemDescriptionPage()
        {
            this.InitializeComponent();
            parseObject = new ParseObject("Idea");
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

        public string GenerateStringFromDate(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        private async void Final_Click(object sender, RoutedEventArgs e)
        {
            parseObject["Country"] = viewModel.Country;
            parseObject["Town"] = viewModel.Town;
            parseObject["Address"] = viewModel.Address;
            parseObject["Neighborhood"] = viewModel.Neighborhood;
            byte[] data = File.ReadAllBytes(viewModel.ImagePath);

            var newImageName = GenerateStringFromDate(DateTime.Now);
            newImageName += ".jpg";

            ParseFile file = new ParseFile(newImageName, data);
            await file.SaveAsync();
            parseObject["Image"] = file;
            await parseObject.SaveAsync();
        }
    }
}
