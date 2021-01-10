using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public class LocationEvent : Event
    {
        public LatLng LatLng { get; set; }
        public LatLngBounds LatLngBounds { get; set; }
        public double Accuracy { get; set; }
        public double Altitude { get; set; }
        public double AltitudeAccuracy { get; set; }
        public double Heading { get; set; }
        public double Speed { get; set; }
        public double Timestamp { get; set; }
    }
}
