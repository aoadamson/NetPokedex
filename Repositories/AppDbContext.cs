using Microsoft.EntityFrameworkCore;
using Pokedex.Repositories.Models;

namespace Pokedex.Repositories;

public class AppDbContext : DbContext
{
    // Constructor that takes the DbContextOptions
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pokemon> pokemondb { get; set; }
}