using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; }
        public ProductContext(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(config["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        public static void SeedData(IMongoCollection<Product> products)
        {
            var productsExists = products.Find(m => true).Any();
            if (!productsExists)
            {
                products.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        public static List<Product> GetPreconfiguredProducts()
        {
            return new List<Product>() {
            new Product() { Name = "IPhone X", Description = "The phone with good camerga", ImageFile = "product-1.png", Price = 120000M, Category = "SmartPhone"},
            new Product() { Name = "Samsung S20+", Description = "BigScreen Phone", ImageFile = "product-2.png", Price = 60000M, Category = "SmartPhone"},
            new Product() { Name = "Oppo", Description = "chinese phone", ImageFile = "product-3.png", Price = 20000M, Category = "SmartPhone"},
            new Product() { Name = "Vivo", Description = "chinese phone", ImageFile = "product-4.png", Price = 20000M, Category = "SmartPhone"},
            };
        }
    }
}
