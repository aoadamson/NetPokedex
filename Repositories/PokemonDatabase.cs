using Pokedex.Repositories.Models;

namespace Pokedex.Repositories;

public interface IPokemonDatabase
{
    List<Pokemon?> GetPokemonById(List<int> ids);
    Pokemon InsertPokemon(Pokemon pokemonToInsert);
}

public class PokemonDatabase : IPokemonDatabase
{
    private readonly AppDbContext _db;

    public PokemonDatabase(AppDbContext db)
    {
        _db = db;
    }

    public List<Pokemon?> GetPokemonById(List<int> ids)
    {
        return ids.Select(id => _db.Pokemons.Find(id)).ToList();
    }

    public Pokemon InsertPokemon(Pokemon pokemonToInsert)
    {
        return _db.Pokemons.Add(pokemonToInsert).Entity;
    }
}