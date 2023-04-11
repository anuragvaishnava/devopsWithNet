using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get;  }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);

        }
        private static void SeedData(IMongoCollection<Product> productsCollection)
        {
            bool existsProducts= productsCollection.Find(productsCollection=>true).Any();
            if (!existsProducts)
            {
                productsCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        public static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
        {
            new Product()
            {
                Name="Smasung",
                Category="A",
                ImageFile="Samsung.png",
                Price=1.0M,
            },
            new Product()
            {
                Name="Iphone",
                Category="B",
                ImageFile="Iphone.png",
                Price=1.0M,
            }
        };
        }


    }
}
