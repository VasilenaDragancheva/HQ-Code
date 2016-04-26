namespace Orders
{ 
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    public class DataUpload
    {
        private const string DefaultCategoriesFileName = "../../Data/categories.txt";
        private const string DefaultProductsFileName = "../../Data/products.txt";
        private const string DefaultOrdersFileName = "../../Data/orders.txt";

        private string categoriesFileName;
        private string productsFileName;
        private string ordersFileName;

        public DataUpload(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataUpload()
            : this(DefaultCategoriesFileName, DefaultProductsFileName, DefaultOrdersFileName)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = this.ReadFile(this.categoriesFileName, true);
            return categories
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = this.ReadFile(this.productsFileName, true);
            return products
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = this.ReadFile(this.ordersFileName, true);
            return orders
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }

        private List<string> ReadFile(string filename, bool hasHeader)
        {
            var fileLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    fileLines.Add(currentLine);
                }
            }

            return fileLines;
        }
    }
}
