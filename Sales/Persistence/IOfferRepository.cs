namespace Sales.Persistence;

public interface IOfferRepository
{
    Task<Domain.Offer?> Get(int Id);

    Task SaveChanges();
}