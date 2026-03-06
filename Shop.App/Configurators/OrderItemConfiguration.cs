using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Configurators;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        //builder
        //    .ToTable("OrderItems");

        //builder
        //    .HasKey(x => x.Id);

        //builder
        //    .Property(o => o.Price)
        //    .HasColumnType("decimal(18,2)");

        //builder
        //    .Property(o => o.Quantity)
        //    .IsRequired();

        //builder
        //    .HasOne(o => o.Order)
        //    .WithMany(o => o.OrderItems)
        //    .HasForeignKey(o => o.OrderId);

        //builder
        //    .HasOne(o => o.Product)
        //    .WithMany(p => p.OrderItems)
        //    .HasForeignKey(o => o.ProductId)
        //    .OnDelete(DeleteBehavior.Restrict);

    }

}
