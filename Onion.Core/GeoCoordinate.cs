using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core
{
    public class GeoCoordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinate(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
        }
    }
}
