using Auction_Rocketseat.API.Entities;

namespace Auction_Rocketseat.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
