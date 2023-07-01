using Sales.Features.Offer;
using Sales.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;

namespace Sales.Tests;

[TestClass]
public class OfferTests
{
    [TestMethod]
    public async Task EditOffer_ShouldSucceed()
    {
        // Arrange
        using var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var dbOptions = new DbContextOptionsBuilder<SalesDbContext>()
            .UseSqlite(connection)
            .Options;

        var offer = new Domain.Offer { Price = 10 };
        using (var context = new SalesDbContext(dbOptions))
        {
            await context.Database.EnsureCreatedAsync();
            context.Offers.Add(offer);
            await context.SaveChangesAsync();
        }

        // Act
        var command = new Features.Offer.Edit.Command
        {
            Id = 1,
            Price = 100
        };

        using (var context = new SalesDbContext(dbOptions))
        {
            var repo = new OfferRepository(context);
            var commandHandler = new Features.Offer.Edit.CommandHandler(repo);
            await commandHandler.Handle(command);
        }
            
        // Assert
        using (var context = new SalesDbContext(dbOptions))
        {
            var updatedOffer = await context.Offers.FindAsync(command.Id);
            Assert.AreNotEqual(offer.Price, updatedOffer!.Price);
            Assert.AreEqual(updatedOffer!.Price, command.Price);
        }
    }
}