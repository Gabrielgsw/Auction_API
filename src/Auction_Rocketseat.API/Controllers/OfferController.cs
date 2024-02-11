using Auction_Rocketseat.API.Communication.Requets;
using Auction_Rocketseat.API.Filters;
using Auction_Rocketseat.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Auction_Rocketseat.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : Auction_RocketseatBaseController
{
    [HttpPost]
    [Route("{itemId}")]

    public IActionResult CreateOffer([FromRoute] int itemId,[FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
    {

        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
