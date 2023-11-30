using Pokedex.Repositories;
using Pokedex.Repositories.Models;

namespace Pokedex.Services;

public interface IPokedexService
{
    Pokemon GetPokemonById(int id);
    bool PokemonExists(int id);
    bool CreatePokemon(Pokemon pokemonToCreate);
}

public class PokedexService : IPokedexService
{
    private readonly IPokemonDatabase _database;

    public PokedexService(IPokemonDatabase database)
    {
        _database = database;
    }

    public Pokemon GetPokemonById(int id) => _database.GetPokemonById(new List<int> { id }).First();

    public bool PokemonExists(int id)
    {
        return _database.GetPokemonById(new List<int> { id }).Any();
    }

    public bool CreatePokemon(Pokemon pokemonToCreate)
    {
        return _database.InsertPokemon(pokemonToCreate) is not null;
    }
}