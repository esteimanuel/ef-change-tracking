using Sales.Persistence;

namespace Sales.Features.Offer;

public static class Edit
{
    public class Command
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }

    public class CommandHandler
    {
        private readonly IOfferRepository offerRepository;

        public CommandHandler(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task Handle(Command command)
        {
            var offer = await this.offerRepository.Get(command.Id);
            offer.Price = command.Price;
            await this.offerRepository.SaveChanges();
        }
    }
}