using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }

    [MaxLength(1000)]
    [Required]
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
}
