using Sales.Persistence;

namespace Sales.Infrastructure.Persistence;

public class OfferRepository : IOfferRepository
{
    private readonly SalesDbContext salesDb;

    public OfferRepository(SalesDbContext salesDb)
    {
        this.salesDb = salesDb;
    }

    public async Task<Domain.Offer?> Get(int id)
    {
        return await this.salesDb.Offers.FindAsync(id);
    }

    public async Task SaveChanges()
    {
        await this.salesDb.SaveChangesAsync();
    }
}