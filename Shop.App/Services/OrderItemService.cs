using Shop.App.Data;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Services;

public class OrderItemService(ShopDbContext _context)
{
    public Order AddOrder(int userId)
    {
        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.Now,
            Status = OrderStatus.PENDING, 
            TotalAmount = 0, 
            OrderItems = new List<OrderItem>()
        };

        _context.Orders.Add(order);
        _context.SaveChanges();

        return order;
    }

    public void AddProductToOrder(int orderId, int productId, int quantity)
    {
      
        var product = _context.Products.FirstOrDefault(x => x.Id == productId);

        if (product == null)
        {
            Console.WriteLine("Product not found");
            return;
        }

        var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found");
            return;
        }

        var orderItem = new OrderItem
        {
            OrderId = orderId,
            ProductId = productId,
            Quantity = quantity,
            Price = product.Price 
        };

        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();
        CalculateTotalAmount(orderId);
    }

    public void CalculateTotalAmount(int orderId)
    {
        var total = _context.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .Sum(oi => oi.Price * oi.Quantity);

        var order = _context.Orders.Find(orderId);
        if (order != null)
        {
            order.TotalAmount = total;
            _context.SaveChanges();
        }
    }

    public void ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = _context.Orders.Find(orderId);
        if (order == null)
        {
            Console.WriteLine("Order not found");
            return;
        }

        order.Status = status;
        _context.SaveChanges();
    }

    public Order GetOrderById(int orderId)
    {
        return _context.Orders.Find(orderId);
    }

    public List<OrderItem> GetOrderItems(int orderId)
    {
        return _context.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .ToList();
    }

    public void CreateOrder(ICollection<(Product product, int quantity)> items, int userId)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var order = new Order { 
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.PENDING,
                TotalAmount = 0
            };

            _context.Orders.Add(order);
            _context.SaveChanges();


            foreach (var item in items)
            {
                if(item.product == null)
                {
                    throw new Exception("Product not found");
                }
                if(item.product.StockQuantity < item.quantity)
                {
                    throw new Exception("Not enough product in store");
                }
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.product.Id,
                    Quantity = item.quantity,
                    Price = item.product.Price
                };

                item.product.StockQuantity -= item.quantity;

                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();

                order.TotalAmount += item.product.Price * item.quantity; ; 
            }


            _context.SaveChanges();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw (new Exception("Error"));
        }
    }
}
