﻿namespace FisSst.Maps.Models
{
    public class CircleOptions : PathOptions
    {
        public CircleOptions()
        {
            Fill = true;
            Radius = 10;
        }

        public double Radius { get; init; }
    }
}