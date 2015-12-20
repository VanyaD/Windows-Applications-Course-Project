namespace CareAndShareApp.Pages
{
    using Parse;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class ListProblemsPage : Page
    {
        public ListProblemsPage()
        {
            this.InitializeComponent();
            getObjectsFromDb();
        }

        public async void getObjectsFromDb()
        {
            var lists = new ViewModel();
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Idea");
            IEnumerable<ParseObject> ideas = await query.FindAsync();

            var ideasList = new List<LocatorViewModel>();
            
            foreach (ParseObject idea in ideas)
            {
                var locModel = new LocatorViewModel();

                string country = idea.Get<string>("Country");
                string town = idea.Get<string>("Town");
                string address = idea.Get<string>("Address");
                string nb = idea.Get<string>("Neighborhood");
                ParseFile img = idea.Get<ParseFile>("Image");

                locModel.Country = country;
                locModel.Town = town;
                locModel.Address = address;
                locModel.Neighborhood = nb;
                locModel.ImageSource = img.Url;

                ideasList.Add(locModel);
            }
            
            lists.Problems = ideasList;
            this.DataContext = lists;
        }
    }
}
