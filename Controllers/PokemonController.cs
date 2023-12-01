using Microsoft.AspNetCore.Mvc;
using Pokedex.Repositories.Models;
using Pokedex.Services;

namespace Pokedex.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController(IPokedexService pokedexService) : ControllerBase // fancy dependency injection
{
    [HttpGet]
    [Route("/getPokemon")]
    public ActionResult<Pokemon> GetPokemonById(string id)
    {
        return pokedexService.GetPokemonById(id);
    }

    [HttpPost]
    [Route("/postPokemon")]
    public ActionResult CreatePokemon(Pokemon pokemonToInsert)
    {
        if (pokedexService.PokemonExists(pokemonToInsert.Id))
        {
            return StatusCode(401);
        }
        pokedexService.CreatePokemon(pokemonToInsert);
        return StatusCode(201);
    }
}