namespace Surfaces
{
    using System.Windows;
    using System.Windows.Media.Media3D;

    public abstract class Surface : ModelVisual3D
    {
        public static PropertyHolder<Material, Surface> MaterialProperty =
            new PropertyHolder<Material, Surface>("Material", null, OnMaterialChanged);

        public static PropertyHolder<Material, Surface> BackMaterialProperty =
            new PropertyHolder<Material, Surface>("BackMaterial", null, OnBackMaterialChanged);

        public static PropertyHolder<bool, Surface> VisibleProperty = new PropertyHolder<bool, Surface>(
            "Visible", 
            true, 
            OnVisibleChanged);

        private readonly GeometryModel3D _content = new GeometryModel3D();

        public Surface()
        {
            this.Content = this._content;
            this._content.Geometry = this.CreateMesh();
        }

        public Material BackMaterial
        {
            get
            {
                return BackMaterialProperty.Get(this);
            }

            set
            {
                BackMaterialProperty.Set(this, value);
            }
        }

        public Material Material
        {
            get
            {
                return MaterialProperty.Get(this);
            }

            set
            {
                MaterialProperty.Set(this, value);
            }
        }

        public bool Visible
        {
            get
            {
                return VisibleProperty.Get(this);
            }

            set
            {
                VisibleProperty.Set(this, value);
            }
        }

        protected static void OnGeometryChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnGeometryChanged();
        }

        protected abstract Geometry3D CreateMesh();

        private static void OnBackMaterialChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnBackMaterialChanged();
        }

        private static void OnMaterialChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnMaterialChanged();
        }

        private static void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnVisibleChanged();
        }

        private void OnBackMaterialChanged()
        {
            this.SetContentBackMaterial();
        }

        private void OnGeometryChanged()
        {
            this._content.Geometry = this.CreateMesh();
        }

        private void OnMaterialChanged()
        {
            this.SetContentMaterial();
        }

        private void OnVisibleChanged()
        {
            this.SetContentMaterial();
            this.SetContentBackMaterial();
        }

        private void SetContentBackMaterial()
        {
            this._content.BackMaterial = this.Visible ? this.BackMaterial : null;
        }

        private void SetContentMaterial()
        {
            this._content.Material = this.Visible ? this.Material : null;
        }
    }
}