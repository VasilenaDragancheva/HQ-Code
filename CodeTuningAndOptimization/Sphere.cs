namespace Surfaces
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public sealed class Sphere : Surface
    {
        private static readonly PropertyHolder<Point3D, Sphere> PositionProperty =
            new PropertyHolder<Point3D, Sphere>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        private static readonly PropertyHolder<double, Sphere> RadiusProperty =
            new PropertyHolder<double, Sphere>("Radius", 1.0, OnGeometryChanged);

        private Point3D _position;

        private double _radius;

        public Point3D Position
        {
            get
            {
                return PositionProperty.Get(this);
            }

            set
            {
                PositionProperty.Set(this, value);
            }
        }

        public double Radius
        {
            get
            {
                return RadiusProperty.Get(this);
            }

            set
            {
                RadiusProperty.Set(this, value);
            }
        }

        protected override Geometry3D CreateMesh()
        {
            this._radius = this.Radius;
            this._position = this.Position;

            const int angleSteps = 32;
            const double minAngle = 0;
            const double maxAngle = 2 * Math.PI;
            const double dAngle = (maxAngle - minAngle) / angleSteps;

            const int ySteps = 32;
            const double minY = -1.0;
            const double maxY = 1.0;
            const double dy = (maxY - minY) / ySteps;

            MeshGeometry3D mesh = new MeshGeometry3D();

            for (int yi = 0; yi <= ySteps; yi++)
            {
                double y = minY + yi * dy;

                for (int ai = 0; ai <= angleSteps; ai++)
                {
                    double angle = ai * dAngle;

                    mesh.Positions.Add(this.GetPosition(angle, y));
                    mesh.Normals.Add(this.GetNormal(angle, y));
                    mesh.TextureCoordinates.Add(this.GetTextureCoordinate(angle, y));
                }
            }

            for (int yi = 0; yi < ySteps; yi++)
            {
                for (int ai = 0; ai < angleSteps; ai++)
                {
                    int a1 = ai;
                    int a2 = ai + 1;
                    int y1 = yi * (angleSteps + 1);
                    int y2 = (yi + 1) * (angleSteps + 1);

                    mesh.TriangleIndices.Add(y1 + a1);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y1 + a2);

                    mesh.TriangleIndices.Add(y1 + a2);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y2 + a2);
                }
            }

            mesh.Freeze();
            return mesh;
        }

        private Vector3D GetNormal(double angle, double y)
        {
            return (Vector3D)this.GetPosition(angle, y);
        }

        private Point3D GetPosition(double angle, double y)
        {
            double r = this._radius * Math.Sqrt(1 - y * y);
            double x = r * Math.Cos(angle);
            double z = r * Math.Sin(angle);

            return new Point3D(this._position.X + x, this._position.Y + this._radius * y, this._position.Z + z);
        }

        private Point GetTextureCoordinate(double angle, double y)
        {
            Matrix map = new Matrix();
            map.Scale(1 / (2 * Math.PI), -0.5);

            Point p = new Point(angle, y);
            p = p * map;

            return p;
        }
    }
}