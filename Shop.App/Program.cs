using Microsoft.Extensions.DependencyInjection;
using Shop.App.Configurators;
using Shop.App.Data;
using Shop.App.Services;
using Shop.Domain.Entities;
using Shop.Domain.Enums;

namespace Shop.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection(); //Створюється контейнер DI (Dependency Injection)

            services.AddDbContext<ShopDbContext>(options =>
            {
                DbContextConfigurator.Configure(options);
            });

            services.AddScoped<OrderItemService>();
            services.AddScoped<Shop>();
            //Створюється вже «працюючий» контейнер.
            var provider = services.BuildServiceProvider();

            //"Один DbContext на одну операцію роботи з БД"

            using var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
          

            if (context.Database.CanConnect())
            {

                //var service = new OrderItemService(context);
                //var shop = new Shop(service);

                //while (true)
                //{
                //    Console.WriteLine();
                //    Console.WriteLine("1 - Add Order");
                //    Console.WriteLine("2 - Add Product To Order");
                //    Console.WriteLine("3 - Change Order Status");
                //    Console.WriteLine("4 - Get Order By Id");
                //    Console.WriteLine("5 - Get Order Items");
                //    Console.WriteLine("0 - Exit");

                //    var choice = Console.ReadLine();

                //    switch (choice)
                //    {
                //        case "1":
                //            shop.AddOrder();
                //            break;

                //        case "2":
                //            shop.AddProductToOrder();
                //            break;

                //        case "3":
                //            shop.ChangeOrderStatus();
                //            break;

                //        case "4":
                //            shop.GetOrderById();
                //            break;

                //        case "5":
                //            shop.GetOrderItems();
                //            break;

                //        case "0":
                //            return;
                //    }
                //}

                //var user = new User
                //{
                //    Name = "Olga",
                //    Surname = "Shevchenko",
                //    Email = "olga@gmail.com",
                //    Role = UserRole.ADMIN,
                //    HeshPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("1234")
                //};
                //context.Add(user);
                //context.SaveChanges();

                //var product = new Product
                //{
                //    Name = "Mouse",
                //    Price = 500,
                //    CreatedAt = DateTime.Now
                //};
                //context.Add(product);
                //context.SaveChanges();

                //SEEDERS
                //var product = new Product
                //{
                //    Name = "батон",
                //    Price = 30.6m,
                //    CreatedAt = DateTime.Now
                //};
                //var product = new Product
                //{
                //    Name = "булочка",
                //    Price = 30.6m,
                //    CreatedAt = DateTime.Now
                //};
                //context.Products.Add(product);
                //context.SaveChanges();
                //var productCategory = new CategoryProduct
                //{
                //    ProductId = 4,
                //    CategoryId = 2,
                //    Store = 16
                //};
                //context.Add(productCategory);
                //context.SaveChanges();



                //Console.WriteLine("Пiдключення до БД встановлено");
                //User user = new User();

                //user.Name = "Bob";
                //user.Surname = "Smith";
                //user.Email = "bob@gmail.com";
                //user.Role = UserRole.ADMIN;
                //user.HeshPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty");
                //context.Users.Add(user);
                //context.SaveChanges();
                //string email = "alexe@gmail.com";
                //string password = "qwerty";
                //var user = context.Users.FirstOrDefault(u => u.Email == email);
                //if (user != null) {
                //    if(BCrypt.Net.BCrypt.EnhancedVerify(password, user.HeshPassword))
                //    {
                //        Console.WriteLine("Login");
                //    }
                //}

            }
            else
            {
                Console.WriteLine("Не вдалось підключитись до БД");
            }

        }
    }
}
