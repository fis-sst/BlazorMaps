using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public class LatLngBounds
    {
        public LatLngBounds(LatLng corner1, LatLng corner2)
        {
            Corner1 = corner1;
            Corner2 = corner2;
        }

        public LatLng Corner1 { get; set; } 
        public LatLng Corner2 { get; set; }
    }
}
