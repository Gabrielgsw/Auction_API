using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Repositories;

namespace Auction_Rocketseat.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoggedUser(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }

    

    public User User()
    {
        var repository = new Auction_RocketseatDbContext();

        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return repository.Users.First(user => user.Email.Equals(email));
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        //"Bearer aasidjiajsdastoken="   

       

        return authentication["Bearer ".Length..]; // -> Retornar uma string a partir da posicao 7
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
