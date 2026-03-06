using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Configurators;

public class ConfigurationUser : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        //builder
        //    .Property(u => u.CreatedAt)
        //    .HasDefaultValueSql("SYSDATETIME()");

        //builder
        //    .HasKey(u => u.Id);

        //builder
        //    .Property(u => u.Email)
        //    .IsRequired();

        //builder
        //    .HasIndex(u => u.Email)
        //    .IsUnique();

        //builder.Property(u=> u.Surname)
        //    .IsRequired()
        //    .HasMaxLength(100);

        //builder.Property(u => u.Name)
        //    .IsRequired()
        //    .HasMaxLength(100);

        //builder.ToTable(t => t.HasCheckConstraint("CK_User_Name_Length", "LEN(Name) >= 1"));
        //builder.ToTable(t => t.HasCheckConstraint("CK_User_Surname_Length", "LEN(Surname) >= 1"));
        //builder.ToTable(t => t.HasCheckConstraint("CK_User_Role", "[Role] BETWEEN 0 AND 3"));
    }
}
