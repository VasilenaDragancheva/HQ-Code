namespace Surfaces
{
    using System.Windows;

    public class PropertyHolder<PropertyType, HoldingType>
        where HoldingType : DependencyObject
    {
        public PropertyHolder(string name, PropertyType defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            this.Property = DependencyProperty.Register(
                name, 
                typeof(PropertyType), 
                typeof(HoldingType), 
                new PropertyMetadata(defaultValue, propertyChangedCallback));
        }

        public DependencyProperty Property { get; private set; }

        public PropertyType Get(HoldingType obj)
        {
            return (PropertyType)obj.GetValue(this.Property);
        }

        public void Set(HoldingType obj, PropertyType value)
        {
            obj.SetValue(this.Property, value);
        }
    }
}