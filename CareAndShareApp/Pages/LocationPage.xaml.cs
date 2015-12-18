using CareAndShareApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CareAndShareApp.Pages
{

    public sealed partial class LocationPage : Page
    {
        LocatorViewModel viewModel;

        public LocationPage()
        {
            this.InitializeComponent();
            this.DataContext = new LocatorViewModel();
            viewModel = new LocatorViewModel();
        }

        private async void GetLocationButtonClick(object sender, RoutedEventArgs e)
        {
            var position = await LocationManager.GetPosition();
            this.tbLatitude.Text = position.Coordinate.Latitude.ToString();
            this.tbLongitude.Text = position.Coordinate.Longitude.ToString();
            ReverseGeocode(position.Coordinate.Latitude, position.Coordinate.Longitude);
        }

        private async void ReverseGeocode(double latitude, double longitude)
        {

            BasicGeoposition location = new BasicGeoposition();
            location.Latitude = latitude;
            location.Longitude = longitude;
            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            // If the query returns results, display the name of the town
            // contained in the address of the first result.
            var cnt = result.Locations[0].Address.Country;
            var twn = result.Locations[0].Address.Town;
            var nbr = result.Locations[0].Address.District;
            var adr = result.Locations[0].Address.FormattedAddress;

            if (result.Status == MapLocationFinderStatus.Success)
            {
                this.tbCountry.Text = "Country = " +
                    result.Locations[0].Address.Country;

                this.tbTown.Text = "Town = " +
                    result.Locations[0].Address.Town;

                this.tbNeighborhood.Text = "Neighborhood = " +
                    result.Locations[0].Address.District;

                this.tbAddress.Text = "Address = " +
                    result.Locations[0].Address.FormattedAddress;
            }

            viewModel.Address = adr;
            viewModel.Country = cnt;
            viewModel.Neighborhood = nbr;
            viewModel.Town = twn;

            MapControlLocator.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            });
            MapControlLocator.ZoomLevel = 18;
            MapControlLocator.LandmarksVisible = true;
            this.GoToSecondPageButton.Visibility = Visibility.Visible;
        }

        private void GoToSecondPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CameraPage), viewModel);
        }
    }
}