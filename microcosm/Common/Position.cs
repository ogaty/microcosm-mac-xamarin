using System;
namespace microcosm.Common
{
    public class Position
    {
        public double x;
        public double y;

        public Position()
        {
            this.x = 0;
            this.y = 0;
        }

        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
