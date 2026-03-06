using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    [Required]
    public string Surname { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;
    public string? HeshPassword { get; set; }

    [Range(0, 3)]
    public UserRole Role { get; set; } = UserRole.USER;
    public DateTime CreatedAt { get; set; }
    public ICollection<Order>? Orders { get; set; }  
}
