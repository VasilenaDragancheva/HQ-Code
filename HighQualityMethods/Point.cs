﻿namespace Methods
{
    public struct Point
    {
        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}