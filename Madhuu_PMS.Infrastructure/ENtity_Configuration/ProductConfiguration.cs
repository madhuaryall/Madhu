using Madhuu_PMS.Model.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madhuu_PMS.Infrastructure.ENtity_Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ProductName)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(e => e.ProductDescription)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(e => e.Rate);
            builder.Property(e => e.quantity);


            builder.Property(e => e.batchNo)
                .HasMaxLength(100)
                .IsUnicode(true);


            builder.Property(e => e.ImageUrl)
               .HasMaxLength(300)
               .IsUnicode(true);
            builder.Property(e => e.IsAvailable);

            builder.Property(e => e.ExpiryDate);
            

          

            builder.Property(e => e.productionDate);

            builder.HasOne(e => e.Category)
                 .WithMany(s => s.Products)
                 .HasForeignKey(e => e.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}