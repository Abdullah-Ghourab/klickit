using klickit.Core.Entities;
using klickit.Data;

namespace klickit.Seeds
{
    public class DefaultProducts
    {
        public static async Task SeedProductAsync(ApplicationDbContext context)
        {

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                  


                new Product
                {
                    Name = "Product 1",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },
                 new Product
                {
                    Name = "Product 2",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                }, new Product
                {
                    Name = "Product 3",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                }, new Product
                {
                    Name = "Product 4",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                }, new Product
                {
                    Name = "Product 5",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                }, new Product
                {
                    Name = "Product 6",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },new Product
                   {
                    Name = "Product 7",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },new Product
                     {
                    Name = "Product 8",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },new Product
                       {
                    Name = "Product 9",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },new Product
                         {
                    Name = "Product 10",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },new Product  {
                    Name = "Product 11",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },
                    new Product  {
                    Name = "Product 12",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },
                      new Product {
                    Name = "Product 13",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                }, new Product {
                    Name = "Product 14",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },
                      new Product   {
                    Name = "Product 15",
                    Price = 9.99m,
                    Description = "This is the description for Product 1.",
                    ImgUrl = ""
                },
                        new Product
                    {
                        Name = "Product 16",
                        Price = 9.99m,
                        Description = "This is the description for Product 1.",
                        ImgUrl = ""
                    },
                    new Product
                    {
                        Name = "Product 17",
                        Price = 19.99m,
                        Description = "This is the description for Product 2.",
                        ImgUrl = ""
                    },
                };
               await context.Products.AddRangeAsync(products);
               await context.SaveChangesAsync();
            }

        }
    }
}

