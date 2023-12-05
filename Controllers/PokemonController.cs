using Microsoft.AspNetCore.Mvc;
using Pokedex.Repositories.Models;
using Pokedex.Services;

namespace Pokedex.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController(IPokedexService pokedexService) : ControllerBase // fancy dependency injection
{
    [HttpGet]
    [Route("getPokemon")]
    public ActionResult<Pokemon> GetPokemonByName(string name)
    {
        return pokedexService.GetPokemonByName(name);
    }

    [HttpPut]
    [Route("postPokemon")]
    public ActionResult CreatePokemon(Pokemon pokemonToInsert)
    {
        if (pokedexService.PokemonExists(pokemonToInsert.name))
        {
            return StatusCode(200);
        }
        pokedexService.CreatePokemon(pokemonToInsert);
        return StatusCode(201);
    }
    [HttpPut]
    [Route("postBulkPokemon")]
    public ActionResult BulkCreatePokemon(List<Pokemon> pokemonToInsert)
    {
        foreach (var pokemon in pokemonToInsert)
        {
            if (pokedexService.PokemonExists(pokemon.name))
            {
                return StatusCode(400);
            }
        }
        pokedexService.BulkCreatePokemon(pokemonToInsert);
        return StatusCode(201);
    }

    [HttpDelete]
    [Route("deletePokemon")]
    public ActionResult DeletePokemon(string name)
    {
        if (pokedexService.PokemonExists(name))
        {
            pokedexService.DeletePokemon(name);
            return StatusCode(201);
        }
        return StatusCode(400);
    }
}