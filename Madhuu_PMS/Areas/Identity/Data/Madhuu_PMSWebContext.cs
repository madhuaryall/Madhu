using Madhuu_PMS.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Madhuu_PMS.Web.Data;

public class Madhuu_PMSWebContext : IdentityDbContext<Madhuu_PMSWebUser>
{
    public Madhuu_PMSWebContext(DbContextOptions<Madhuu_PMSWebContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
