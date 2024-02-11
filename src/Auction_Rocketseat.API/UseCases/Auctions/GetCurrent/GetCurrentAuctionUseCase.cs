using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction_Rocketseat.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new Auction_RocketseatDbContext();

        return repository.Auctions.Include(auction => auction.Items).First();
    }


}
