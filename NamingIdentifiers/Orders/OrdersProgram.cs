namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class OrdersProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataUpload = new DataUpload();
            var categories = dataUpload.GetAllCategories();
            var products = dataUpload.GetAllProducts();
            var orders = dataUpload.GetAllOrders();

            // Names of the 5 most expensive products
            var fiveMostExpensiceProducts = products
                .OrderByDescending(product => product.UnitPrice)
                .Take(5)
                .Select(product => product.Name);
            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiceProducts));
            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var productsCountPerCategory = products
                .GroupBy(product => product.CategoryId)
                .Select(group => new { Category = categories.First(c => c.Id == group.Key).Name, Count = group.Count() })
                .ToList();
            foreach (var item in productsCountPerCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var fiveMostOrderedProducts = orders
                .GroupBy(o => o.ProductId)
                .Select(grp => new { Product = products.First(p => p.Id == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var item in fiveMostOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitableCategory = orders
                .GroupBy(order => order.ProductId)
                .Select(productGroup => new { Id = products.First(product => product.Id == productGroup.Key).CategoryId,
                                       Price = products.First(product => product.Id == productGroup.Key).UnitPrice, 
                                       Quantity = productGroup.Sum(product => product.Quantity) })
                .GroupBy(group => group.Id)
                .Select(group =>new { GategoryName = categories.First(category => category.Id == group.Key).Name, 
                                      TotalQuantity = group.Sum(gr=> gr.Quantity*gr.Price) })
                .OrderByDescending(group=>group.TotalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.GategoryName, mostProfitableCategory.TotalQuantity);
        }
    }
}
