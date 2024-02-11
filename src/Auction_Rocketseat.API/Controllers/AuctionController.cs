using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Rocketseat.API.Controllers;

public class AuctionController : Auction_RocketseatBaseController
{
    [HttpGet] //Endpoint para recuperar info
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        // Retorna um status code

        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        if(result == null)
        {
            return NoContent();
        }

        return Ok("Ok"); 
    }

    
}
