using Microsoft.EntityFrameworkCore;
using Shop.App.Data;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Repositories;

public class ProductRepository(ShopDbContext _context)
{
    //    В репозіторії створити методи по роботі з продуктом:
    //Створення продукта, виборка всіх продуктів(з AsNoTracking()),
    //оновлення ціни продукта, видалення продукта за Id.


    public void CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
    public ICollection<Product> GetAllProducts()
    {
        return _context.Products
            .Include(p => p.CategoryProducts)
            .ThenInclude(cp => cp.Category)
            .AsNoTracking()
            .ToList();
    }

    public void DeleteProductById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public void UpdateProductPrice(int Id, decimal price)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == Id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Price = price;
        _context.SaveChanges();
    }
}
