namespace Pokedex.Repositories.Models;

public class Pokemon
{
    public int Id { get; set; }
    public PokemonName Name { get; set; }
    public List<string> Type { get; set; }
    public PokemonBase Base { get; set; }
}