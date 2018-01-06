using System;
using System.Collections.Generic;

namespace microcosm.Models
{
    public class Calculation
    {
        public List<PlanetData> planetData;
        public double[] cusps;
        public Calculation(List<PlanetData> p, double[] c)
        {
            planetData = p;
            cusps = c;
        }
    }
}
