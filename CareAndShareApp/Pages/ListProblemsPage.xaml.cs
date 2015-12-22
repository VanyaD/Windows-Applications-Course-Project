namespace CareAndShareApp.Pages
{
    using Parse;
    using System.Collections.Generic;
    using ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class ListProblemsPage : Page
    {
        public ListProblemsPage()
        {
            this.InitializeComponent();
            getObjectsFromDb();
        }

        private void AppBarHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public async void getObjectsFromDb()
        {
            var lists = new ViewModel();
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Idea").OrderByDescending("Priority");
            IEnumerable<ParseObject> ideas = await query.FindAsync();

            var ideasList = new List<LocatorViewModel>();
            
            foreach (ParseObject idea in ideas)
            {
                var locModel = new LocatorViewModel();

                var country = idea.Get<string>("Country");
                var town = idea.Get<string>("Town");
                var address = idea.Get<string>("Address");
                var nb = idea.Get<string>("Neighborhood");
                var description = idea.Get<string>("Comment");
                var title = idea.Get<string>("Title");
                var priority = idea.Get<byte>("Priority");
                var category = idea.Get<string>("Category");
                ParseFile img = idea.Get<ParseFile>("Image");

                locModel.Country = country;
                locModel.Town = town;
                locModel.Address = address;
                locModel.Neighborhood = nb;
                locModel.ImageSource = img.Url;
                locModel.Title = title;
                locModel.Priority = priority;
                locModel.Comment = description;
                locModel.Category = category;

                ideasList.Add(locModel);
            }
            
            lists.Problems = ideasList;
            this.DataContext = lists;
        }
    }
}
