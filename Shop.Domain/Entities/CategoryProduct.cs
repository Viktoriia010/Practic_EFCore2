using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;


public class CategoryProduct
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Category")]

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    [ForeignKey("Product")]
    public int? ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(0, int.MaxValue)]
    public int Store { get; set; }
}
