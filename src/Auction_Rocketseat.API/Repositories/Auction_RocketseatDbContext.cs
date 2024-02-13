using Auction_Rocketseat.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction_Rocketseat.API.Repositories;
// Classe para conseguir acessar as tabelas no db
public class Auction_RocketseatDbContext : DbContext
{
    public Auction_RocketseatDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Auction> Auctions { get; set; } // Mesmo nome da tabela criada no db
    public DbSet<User> Users { get; set; } // Mesmo nome da tabela criada no db
    public DbSet<Offer> Offers { get; set; } // Mesmo nome da tabela criada no db

    
}
