using Auction_Rocketseat.API.Entities;
using Auction_Rocketseat.API.Contracts;

namespace Auction_Rocketseat.API.Repositories.DataAcess;

public class UserRepository : IUserRepository
{
    private readonly Auction_RocketseatDbContext _dbContext;
    public UserRepository(Auction_RocketseatDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}