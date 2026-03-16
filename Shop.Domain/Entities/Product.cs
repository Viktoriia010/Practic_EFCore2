using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
    public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    public ICollection<OrderItem> OrderItems { get; set; }
}
