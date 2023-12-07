using AutoFixture;
using Moq;
using Pokedex.Repositories;
using Pokedex.Repositories.Models;
using Xunit;

namespace Pokedex.Services;

public class PokedexServiceTests
{
    private readonly Mock<IPokemonDatabase> _mockDatabase;
    private readonly Fixture _fixture;
    private readonly PokedexService _pokedexService;

    public PokedexServiceTests()
    {
        _mockDatabase = new Mock<IPokemonDatabase>();
        _fixture = new Fixture();
        _pokedexService = new PokedexService(_mockDatabase.Object);
    }

    [Fact]
    public void GetPokemonByName_ShouldReturnPokemon_WhenExists()
    {
        // Arrange
        var expectedPokemon = _fixture.Create<Pokemon>();
        var pokemonName = expectedPokemon.name;
        _mockDatabase.Setup(db => db.GetPokemonByName(It.IsAny<List<string>>()))
            .Returns(new List<Pokemon> { expectedPokemon });

        // Act
        var result = _pokedexService.GetPokemonByName(pokemonName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedPokemon.name, result.name);
    }
}