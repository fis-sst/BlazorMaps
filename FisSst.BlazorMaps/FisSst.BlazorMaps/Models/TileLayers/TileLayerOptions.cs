using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.BlazorMaps
{
    public class TileLayerOptions
    {
        public string Id { get; set; }
        public string Attribution { get; set; }
        public int MaxZoom { get; set; }
        public int TileSize { get; set; }
        public int ZoomOffset { get; set; }
        public string AccessToken { get; set; }
    }
}
