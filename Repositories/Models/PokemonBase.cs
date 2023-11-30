using System.Text.Json.Serialization;

namespace Pokedex.Repositories.Models;

public class PokemonBase
{
    [JsonPropertyName("HP")] public int Hp { get; set; }

    public int Attack { get; set; }
    public int Defense { get; set; }

    [JsonPropertyName("Sp. Attack")] public int SpAttack { get; set; }

    [JsonPropertyName("Sp. Defense")] public int SpDefense { get; set; }

    public int Speed { get; set; }
}