using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Auction_Rocketseat.API.Contracts;


namespace Auction_Rocketseat.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute() => _repository.GetCurrent();
}

