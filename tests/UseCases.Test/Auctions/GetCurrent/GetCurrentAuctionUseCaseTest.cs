using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Repositories.DataAcess;
using Auction_Rocketseat.API.UseCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Auction_Rocketseat.API.Contracts;
using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Enums;
using Auction_Rocketseat.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        // Arrange

        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 700),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();



        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        // Act
        var auction = useCase.Execute();

        // Assert
        auction.Should().NotBeNull();
        auction.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);
    }
}