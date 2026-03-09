using Microsoft.EntityFrameworkCore;
using Shop.App.Data;
using Shop.App.Services;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App;

class Shop(OrderItemService _service, ShopDbContext context)
{
    public void AddOrder()
    {
        try
        {
            Console.Write("Enter user id: ");
            int id = int.Parse(Console.ReadLine());

            _service.AddOrder(id);
            Console.WriteLine("Order added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void AddProductToOrder()
    {
        try
        {
            Console.Write("Enter order id: ");
            int id2 = int.Parse(Console.ReadLine());
            Console.Write("Enter product id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            _service.AddProductToOrder(id2, id, quantity);
            Console.WriteLine("Product added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    

    public void ChangeOrderStatus()
    {
        try
        {
            Console.Write("Enter order id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter order status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine(), true);

            _service.ChangeOrderStatus(id, status);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void GetOrderById()
    {
        try
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            var o = _service.GetOrderById(id);
            Console.WriteLine($"Order Id: {o.Id}, UserId: {o.UserId}, Total: {o.TotalAmount}, Status: {o.Status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void GetOrderItems()
    {
        try
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            var items = _service.GetOrderItems(id);
            foreach (var item in items)
            {
                Console.WriteLine($"ProductId: {item.ProductId}, Quantity: {item.Quantity}, Price: {item.Price}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void CreateOrder()
    {
        try
        {

            Console.Write("Enter User Id: ");
            int id = int.Parse(Console.ReadLine());

            var items = new List<(Product product, int quantity)>();

            while (true)
            {
                Console.Write("Enter Product Id (0 to complete):");
                int productId = int.Parse(Console.ReadLine());
                if (productId == 0) break;

                var product = context.Products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found");
                    continue;
                }

                Console.WriteLine("Enter the quantity:");
                int quantity = int.Parse(Console.ReadLine());

                items.Add((product, quantity));
            }

            _service.CreateOrder(items, id);

            Console.WriteLine("Order created successfully");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
