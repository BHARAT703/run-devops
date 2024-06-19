using Shopping.Client.Models;

namespace Shopping.Client.Data
{
    public static class ProductContext
    {
        public static readonly List<Product> Products = new List<Product>
        {
            new Product() { Name = "IPhone X", Description = "The phone with good camerga", ImageFile = "product-1.png", Price = 120000M, Category = "SmartPhone"},
            new Product() { Name = "Samsung S20+", Description = "BigScreen Phone", ImageFile = "product-2.png", Price = 60000M, Category = "SmartPhone"},
        };
    }
}
