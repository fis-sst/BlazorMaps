using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisSst.Maps.Models
{
    public class IconOptions
    {
        public string IconUrl { get; init; }
        public string IconRetinaUrl { get; init; }
        public Point IconSize { get; init; }
        public Point IconAnchor { get; init; }
        public Point PopupAnchor { get; init; }
        public Point TooltipAnchor { get; init; }
        public string ShadowUrl { get; init; }
        public string ShadowRetinaUrl { get; init; }
        public Point ShadowSize { get; init; }
        public Point ShadowAnchor { get; init; }
        public string ClassName { get; init; }
    }
}
