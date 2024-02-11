using Auction_Rocketseat.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auction_Rocketseat.API.Filters;

// Criando um token para verificar a autenticacao de um determinado usuario
public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {

        var token = TokenOnRequest(context.HttpContext);

        var repository = new Auction_RocketseatDbContext();
        var email = FromBase64String(token);

        var exist = repository.Users.Any(user => user.Email.Equals(email));

        if(exist == false)
        {
            context.Result = new UnauthorizedObjectResult("E-mail inválido! ");
        }

        }catch(Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();
        //"Bearer aasidjiajsdastoken="   

        if (string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missing. ");
        }

        return authentication["Bearer ".Length..]; // -> Retornar uma string a partir da posicao 7
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }

}