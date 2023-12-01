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
    public ActionResult<Pokemon> GetPokemonById(Guid id)
    {
        return pokedexService.GetPokemonById(id);
    }

    [HttpPut]
    [Route("postPokemon")]
    public ActionResult CreatePokemon(Pokemon pokemonToInsert)
    {
        // if (pokedexService.PokemonExists(pokemonToInsert.pokemon_id))
        // {
        pokedexService.CreatePokemon(pokemonToInsert);
        return StatusCode(201);
        // }
        return StatusCode(200);
    }
}