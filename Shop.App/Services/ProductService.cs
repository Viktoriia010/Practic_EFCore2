using Microsoft.EntityFrameworkCore;
using Shop.App.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Services;

public class ProductService(ProductRepository _repository )
{
    public void CreateProduct(string name, decimal price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Name cannot be empty");

        if (price < 0)
            throw new Exception("Price must be greater than 0");

        if (stockQuantity < 0)
            throw new Exception("Stock cannot be negative");

        Product product = new Product
        {
            Name = name,
            Price = price,
            StockQuantity = stockQuantity,
            CreatedAt = DateTime.Now
        };
        _repository.CreateProduct(product);
    }

    public ICollection<Product> GetAllProducts()
    {
        var products = _repository.GetAllProducts();
        return products;

    }

    public void DeleteProductById(int id)
    {
        if (id <= 0)
            throw new Exception("Id must be greater than 0");

        _repository.DeleteProductById(id);
    }

    public void UpdateProductPrice(int Id, decimal price)
    {
        if (Id <= 0)
            throw new Exception("Id must be greater than 0");
        if (price < 0)
            throw new Exception("Price must be greater than 0");

         _repository.UpdateProductPrice(Id, price);
    }
}
