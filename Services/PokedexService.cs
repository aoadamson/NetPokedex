using Pokedex.Repositories;
using Pokedex.Repositories.Models;

namespace Pokedex.Services;

public interface IPokedexService
{
    Pokemon GetPokemonById(string id);
    bool PokemonExists(string id);
    bool CreatePokemon(Pokemon pokemonToCreate);
}

public class PokedexService : IPokedexService
{
    private readonly IPokemonDatabase _database;

    public PokedexService(IPokemonDatabase database)
    {
        _database = database;
    }

    public Pokemon GetPokemonById(string id) => _database.GetPokemonById(new List<string> { id }).First();

    public bool PokemonExists(string id)
    {
        return _database.GetPokemonById(new List<string> { id }).Any();
    }

    public bool CreatePokemon(Pokemon pokemonToCreate)
    {
        return _database.InsertPokemon(pokemonToCreate) is not null;
    }
}