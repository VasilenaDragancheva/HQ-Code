namespace CohesionAndCoupling
{
    using System;
    using System.Text;

    public class Cuboid : ISolidFigure
    {
        private double depth;

        private double height;

        private double width;

        public Cuboid(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double BaseDiagonal
        {
            get
            {
                double diagonal = Math.Sqrt((this.Width * this.Width) + (this.Height * this.Height));
                return diagonal;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("depth", "depth should be positive");
                }

                this.depth = value;
            }
        }

        public double FaceDiagonalHeight
        {
            get
            {
                double diagonal = Math.Sqrt((this.Height * this.Height) + (this.Depth * this.Depth));
                return diagonal;
            }
        }

        public double FaceDiagonalWidth
        {
            get
            {
                double diagonal = Math.Sqrt((this.Width * this.Width) + (this.Depth * this.Depth));
                return diagonal;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "Height should be positive");
                }

                this.height = value;
            }
        }

        public double SpaceDiagonal
        {
            get
            {
                double spaceDiagonal =
                    Math.Sqrt((this.Width * this.Width) + (this.Depth * this.Depth) + (this.Height * this.Height));
                return spaceDiagonal;
            }
        }

        public double Volume
        {
            get
            {
                return this.Depth * this.Height * this.Width;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("width", "Width should be positive");
                }

                this.width = value;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.AppendFormat(
                "Cuboid with dimensions of {0:f2} cm, {1:f2}, cm and {2:f2} cm ",
                this.Width,
                this.Height,
                this.Depth);

            toString.AppendFormat(" and has volume is {0}", this.Volume);

            return toString.ToString();
        }
    }
}