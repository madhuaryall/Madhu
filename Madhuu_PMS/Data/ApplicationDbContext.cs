using Madhuu_PMS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Madhuu_PMS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<ApplicationUser>()
              .Property(e => e.MiddleName)
              .HasMaxLength(100);

            builder.Entity<ApplicationUser>()
          .Property(e => e.LastName)
          .HasMaxLength(100)
          .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(e => e.PhoneNumber)
                .HasMaxLength(10);

            builder.Entity<ApplicationUser>()
          .Property(e => e.ProfilePictureUrl)
          .HasMaxLength(500);

            builder.Entity<ApplicationUser>()
                .Property(e => e.Address)
                .HasMaxLength(250)
                .IsRequired();


            builder.Entity<ApplicationUser>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.Entity<ApplicationUser>()
                .Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");



            builder.Entity<IdentityRole>()
                .ToTable("Roles")
                .Property(p => p.Id)
                .HasColumnName("RoleId");
        }


    }
}
