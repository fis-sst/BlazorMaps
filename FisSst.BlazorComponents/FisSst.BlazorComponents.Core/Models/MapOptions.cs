using System;
using System.Collections.Generic;
using System.Text;

namespace FisSst.Maps.Models
{
    public class MapOptions
    {
        public string Id { get; set; }
        public string Attribution { get; set; }
        public int MaxZoom { get; set; }        
        public int TileSize { get; set; }
        public int ZoomOffset { get; set; }
        public string AccessToken { get; set; }
    }
}
