using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FisSst.Maps.Models
{
    public class LatLng 
    {
        public LatLng(double lat, double lng)
        {
            Value = new List<double>() { lat, lng };
        }

        internal List<double> Value { get; private set; }

        public double Latitude
        {
            get
            {
                return Value[0];
            }
            set
            {
                Value[0] = value;
            }
        }

        public double Longitude
        {
            get
            {
                return Value[1];
            }
            set
            {
                Value[1] = value;
            }
        }
    }
}
