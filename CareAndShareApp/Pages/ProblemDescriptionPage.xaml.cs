namespace CareAndShareApp.Pages
{
    using CareAndShareApp.ViewModels;
    using Parse;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class ProblemDescriptionPage : Page
    {
        LocatorViewModel viewModel;
        ParseObject parseObject;

        public ProblemDescriptionPage()
        {
            this.InitializeComponent();
            parseObject = new ParseObject("Idea");
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
            if (!IsFieldFilled())
            {
                this.SubmitIdeaButton.Visibility = Visibility.Collapsed;
                this.ErrorPanel.Visibility = Visibility.Visible;
                await Task.Delay(3000);
                this.ErrorPanel.Visibility = Visibility.Collapsed;
                this.SubmitIdeaButton.Visibility = Visibility.Visible;
                return;
            }

            viewModel.Priority = (byte)this.sliderPriority.Value;
            viewModel.Title = this.tbTitle.Text;
            viewModel.Category = this.tbCategory.SelectionBoxItem.ToString(); //default null
            viewModel.Comment = this.tbDescription.Text;

            parseObject["Country"] = viewModel.Country;
            parseObject["Town"] = viewModel.Town;
            parseObject["Address"] = viewModel.Address;
            parseObject["Neighborhood"] = viewModel.Neighborhood;
            parseObject["Title"] = viewModel.Title;
            parseObject["Comment"] = viewModel.Comment;
            parseObject["Category"] = viewModel.Category;
            parseObject["Priority"] = viewModel.Priority;

            byte[] data = File.ReadAllBytes(viewModel.ImagePath);

            var newImageName = GenerateStringFromDate(DateTime.Now);
            newImageName += ".jpg";

            ParseFile file = new ParseFile(newImageName, data);
            await file.SaveAsync();
            parseObject["Image"] = file;

            await parseObject.SaveAsync();
            SuccessfullIdea();
        }

        private bool IsFieldFilled()
        {
            if ((byte)this.sliderPriority.Value != 0 && this.tbTitle.Text != string.Empty && this.tbCategory.SelectionBoxItem != null
                && this.tbDescription.Text != string.Empty)
            {
                return true;
            }
            return false;
        }

        private async void SuccessfullIdea()
        {
            this.SubmitIdeaButton.Visibility = Visibility.Collapsed;
            this.SuccessPanel.Visibility = Visibility.Visible;
            await Task.Delay(5000);
            this.SuccessPanel.Visibility = Visibility.Collapsed;
            this.SubmitIdeaButton.Visibility = Visibility.Visible;
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
