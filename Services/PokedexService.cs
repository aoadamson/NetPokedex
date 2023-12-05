using Pokedex.Repositories;
using Pokedex.Repositories.Models;

namespace Pokedex.Services;

public interface IPokedexService
{
    Pokemon GetPokemonByName(string name);
    bool PokemonExists(string name);
    bool CreatePokemon(Pokemon pokemonToCreate);
    void DeletePokemon(string name);
    bool BulkCreatePokemon(List<Pokemon> pokemonToCreate);

}

public class PokedexService : IPokedexService
{
    private readonly IPokemonDatabase _database;

    public PokedexService(IPokemonDatabase database)
    {
        _database = database;
    }

    public Pokemon GetPokemonByName(string name) => _database.GetPokemonByName(new List<string> { name }).First();

    public bool PokemonExists(string name)
    {
        return _database.GetPokemonByName(new List<string> { name }).Any();
    }

    public bool CreatePokemon(Pokemon pokemonToCreate)
    {
        return _database.InsertPokemon(pokemonToCreate) is not null;
    }

    public void DeletePokemon(string name)
    {
        _database.DeletePokemonByName(name);
    }
    public bool BulkCreatePokemon(List<Pokemon> pokemonToCreate)
    {
        foreach (var pokemon in pokemonToCreate)
        {
            _database.InsertPokemon(pokemon);
        }
        return true;
    }
}