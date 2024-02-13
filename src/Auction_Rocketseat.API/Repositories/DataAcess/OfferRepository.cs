using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Contracts;

namespace Auction_Rocketseat.API.Repositories.DataAcess;

public class OfferRepository : IOfferRepository
{
    private readonly Auction_RocketseatDbContext _dbContext;
    public OfferRepository(Auction_RocketseatDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();

    }
}