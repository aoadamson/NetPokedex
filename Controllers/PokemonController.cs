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
    public ActionResult<Pokemon> GetPokemonById(int id)
    {
        return pokedexService.GetPokemonById(id);
    }

    [HttpPost]
    [Route("/PostPokemon")]
    public ActionResult CreatePokemon(Pokemon pokemonToInsert)
    {
        if (pokedexService.PokemonExists(pokemonToInsert.Id))
        {
            pokedexService.CreatePokemon(pokemonToInsert);
            return StatusCode(201);
        }

        return StatusCode(401);
    }
}