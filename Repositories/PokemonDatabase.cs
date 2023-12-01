using Pokedex.Repositories.Models;

namespace Pokedex.Repositories;

public interface IPokemonDatabase
{
    List<Pokemon?> GetPokemonById(List<Guid> ids);
    Pokemon InsertPokemon(Pokemon pokemonToInsert);
}

public class PokemonDatabase : IPokemonDatabase
{
    private readonly AppDbContext _db;

    public PokemonDatabase(AppDbContext db)
    {
        _db = db;
    }

    public List<Pokemon?> GetPokemonById(List<Guid> ids)
    {
        return ids.Select(id => _db.pokemondb.Find(id)).ToList();
    }

    public Pokemon InsertPokemon(Pokemon pokemonToInsert)
    {
        var result =_db.pokemondb.Add(pokemonToInsert).Entity;
        _db.SaveChanges();
        return result;
    }
}