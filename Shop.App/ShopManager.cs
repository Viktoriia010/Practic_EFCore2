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

class ShopManager(ProductService _productService/*OrderItemService _service*/)
{
    public void Run()
    {
        while ( true ) {

            Console.WriteLine("Select option:");
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine($"{(int)option} - {option}");
            }

            Console.WriteLine("Enter option:");

            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            MenuOption option2 = (MenuOption)number;  

            switch (option2)
            {
                case MenuOption.CreateProduct:
                    CreateProduct();
                    break;

                case MenuOption.GetAllProducts:
                    GetAllProducts();
                    break;

                case MenuOption.UpdateProductPrice:
                    UpdateProductPrice();
                    break;

                case MenuOption.DeleteProduct:
                    DeleteProductById();
                    break;

                case MenuOption.Exit:
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
    private void CreateProduct()
    {
        try
        {
            Console.Write("Enter name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter stock quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            _productService.CreateProduct(productName, price, quantity);
            Console.WriteLine("Product created successfully");
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
       
    }

    private void GetAllProducts()
    {
        var products = _productService.GetAllProducts();
        Console.WriteLine("All products: ");
        foreach (var item in products)
        {
            Console.WriteLine($"\t Id: {item.Id}, Name: {item.Name}, Price: {item.Price}, Date: {item.CreatedAt}");
        }

    }

    private void DeleteProductById()
    {
        Console.Write("Enter id: ");
        int id = int.Parse(Console.ReadLine());
        try
        {
            _productService.DeleteProductById(id);
            Console.WriteLine("Product deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private void UpdateProductPrice()
    {
        Console.Write("Enter id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine());
        try
        {
            _productService.UpdateProductPrice(id, price);
            Console.WriteLine("Product updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    //public void AddOrder()
    //{
    //    try
    //    {
    //        Console.Write("Enter user id: ");
    //        int id = int.Parse(Console.ReadLine());

    //        _service.AddOrder(id);
    //        Console.WriteLine("Order added successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //}

    //public void AddProductToOrder()
    //{
    //    try
    //    {
    //        Console.Write("Enter order id: ");
    //        int id2 = int.Parse(Console.ReadLine());
    //        Console.Write("Enter product id: ");
    //        int id = int.Parse(Console.ReadLine());
    //        Console.Write("Enter quantity: ");
    //        int quantity = int.Parse(Console.ReadLine());

    //        _service.AddProductToOrder(id2, id, quantity);
    //        Console.WriteLine("Product added successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //}



    //public void ChangeOrderStatus()
    //{
    //    try
    //    {
    //        Console.Write("Enter order id: ");
    //        int id = int.Parse(Console.ReadLine());

    //        Console.Write("Enter order status: ");
    //        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine(), true);

    //        _service.ChangeOrderStatus(id, status);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //}

    //public void GetOrderById()
    //{
    //    try
    //    {
    //        Console.Write("Enter Id: ");
    //        int id = int.Parse(Console.ReadLine());

    //        var o = _service.GetOrderById(id);
    //        Console.WriteLine($"Order Id: {o.Id}, UserId: {o.UserId}, Total: {o.TotalAmount}, Status: {o.Status}");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //}

    //public void GetOrderItems()
    //{
    //    try
    //    {
    //        Console.Write("Enter Id: ");
    //        int id = int.Parse(Console.ReadLine());

    //        var items = _service.GetOrderItems(id);
    //        foreach (var item in items)
    //        {
    //            Console.WriteLine($"ProductId: {item.ProductId}, Quantity: {item.Quantity}, Price: {item.Price}\n");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //}

    //public void CreateOrder()
    //{
    //    try
    //    {

    //        Console.Write("Enter User Id: ");
    //        int id = int.Parse(Console.ReadLine());

    //        var items = new List<(Product product, int quantity)>();

    //        while (true)
    //        {
    //            Console.Write("Enter Product Id (0 to complete):");
    //            int productId = int.Parse(Console.ReadLine());
    //            if (productId == 0) break;

    //            var product = context.Products.FirstOrDefault(p => p.Id == productId);
    //            if (product == null)
    //            {
    //                Console.WriteLine("Product not found");
    //                continue;
    //            }

    //            Console.WriteLine("Enter the quantity:");
    //            int quantity = int.Parse(Console.ReadLine());

    //            items.Add((product, quantity));
    //        }

    //        _service.CreateOrder(items, id);

    //        Console.WriteLine("Order created successfully");

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //}
}
