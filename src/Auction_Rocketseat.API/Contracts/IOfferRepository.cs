using Auction_Rocketseat.API.Entities;

namespace Auction_Rocketseat.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
