using System.ComponentModel.DataAnnotations;

namespace Pokedex.Repositories.Models;

public class Pokemon
{
    [Key] public Guid pokemon_id { get; set; }
    public string name { get; set; }
}