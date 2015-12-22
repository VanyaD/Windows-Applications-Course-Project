namespace CareAndShareApp.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;

    public class LocationManager
    {
        public async static Task<Geoposition> GetPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            var geolocator = new Geolocator();
            var position = await geolocator.GetGeopositionAsync();

            return position;
        }
    }
}
