using Pokedex.Repositories;
using Pokedex.Repositories.Models;

namespace Pokedex.Services;

public interface IPokedexService
{
    Pokemon GetPokemonById(Guid id);
    bool PokemonExists(Guid id);
    bool CreatePokemon(Pokemon pokemonToCreate);
}

public class PokedexService : IPokedexService
{
    private readonly IPokemonDatabase _database;

    public PokedexService(IPokemonDatabase database)
    {
        _database = database;
    }

    public Pokemon GetPokemonById(Guid id) => _database.GetPokemonById(new List<Guid> { id }).First();

    public bool PokemonExists(Guid id)
    {
        return _database.GetPokemonById(new List<Guid> { id }).Any();
    }

    public bool CreatePokemon(Pokemon pokemonToCreate)
    {
        return _database.InsertPokemon(pokemonToCreate) is not null;
    }
}