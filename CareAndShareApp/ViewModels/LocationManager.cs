﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace CareAndShareApp.ViewModels
{
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
