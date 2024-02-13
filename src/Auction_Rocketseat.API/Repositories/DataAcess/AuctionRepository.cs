using Auction_Rocketseat.API.Entities;
using Microsoft.EntityFrameworkCore;
using Auction_Rocketseat.API.Contracts;

namespace Auction_Rocketseat.API.Repositories.DataAcess;

public class AuctionRepository : IAuctionRepository
{
    private readonly Auction_RocketseatDbContext _dbContext;
    public AuctionRepository(Auction_RocketseatDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
           .Auctions
           .Include(auction => auction.Items)
           .FirstOrDefault(auction => today >= auction.Starts);
    }
}