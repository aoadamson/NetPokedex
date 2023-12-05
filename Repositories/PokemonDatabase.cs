using Pokedex.Repositories.Models;

namespace Pokedex.Repositories;

public interface IPokemonDatabase
{
    List<Pokemon> GetPokemonByName(List<string> names);
    Pokemon InsertPokemon(Pokemon pokemonToInsert);
    void DeletePokemonByName(string name);
}

public class PokemonDatabase : IPokemonDatabase
{
    private readonly AppDbContext _db;

    public PokemonDatabase(AppDbContext db)
    {
        _db = db;
    }

    public List<Pokemon> GetPokemonByName(List<string> names)
    {
        // Fetch Pokémon by their names
        return _db.pokemondb
            .Where(pokemon => names.Contains(pokemon.name))
            .ToList();
    }

    public Pokemon InsertPokemon(Pokemon pokemonToInsert)
    {
        var result =_db.pokemondb.Add(pokemonToInsert).Entity;
        _db.SaveChanges();
        return result;
    }
    
    public void DeletePokemonByName(string name)
    {
        // Find the Pokémon by name
        var pokemonToDelete = _db.pokemondb.FirstOrDefault(pokemon => pokemon.name == name);
        if (pokemonToDelete == null) return;
        _db.pokemondb.Remove(pokemonToDelete);
        _db.SaveChanges();
    }
}