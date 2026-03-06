using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Range(1,1000, ErrorMessage = "Value must be greater than 1 and less than 1000")]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be less than 0")]
    public decimal Price { get; set; }  
}
