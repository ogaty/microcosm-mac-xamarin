using System;
using System.Collections.Generic;

namespace microcosm.Models
{
    public class Calcuration
    {
        public List<PlanetData> planetData;
        public double[] cusps;
        public Calcuration(List<PlanetData> p, double[] c)
        {
            planetData = p;
            cusps = c;
        }
    }
}
