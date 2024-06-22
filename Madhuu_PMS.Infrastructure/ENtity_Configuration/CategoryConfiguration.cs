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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(e => e.CategoryDescription)
                .HasMaxLength(500)
                .IsUnicode(true);


        }
    }
}