using Microsoft.EntityFrameworkCore;

namespace Sales.Infrastructure.Persistence;

public class SalesDbContext : DbContext
{
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
    {

    }
    
    public DbSet<Domain.Offer> Offers { get; set; }
}
