using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Rocketseat.API.Controllers;

public class AuctionController : Auction_RocketseatBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {

        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }
}
