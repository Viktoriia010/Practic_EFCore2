using Microsoft.Extensions.DependencyInjection;
using Shop.App.Configurators;
using Shop.App.Data;
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


            //Створюється вже «працюючий» контейнер.
            var provider = services.BuildServiceProvider();

            //"Один DbContext на одну операцію роботи з БД"

            using var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();

            if (context.Database.CanConnect())
            {
                Console.WriteLine("Пiдключення до БД встановлено");
                User user = new User();
             
                user.Name = "Bob";
                user.Surname = "Smith";
                user.Email = "bob@gmail.com";
                user.Role = UserRole.ADMIN;
                user.HeshPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty");
                context.Users.Add(user);
                context.SaveChanges();
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
