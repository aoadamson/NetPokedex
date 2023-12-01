using Microsoft.EntityFrameworkCore;
using Pokedex.Repositories;
using Pokedex.Services;

// Assuming your models are in this namespace

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure the connection string for AppDbContext
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        builder.Services.AddTransient<IPokedexService, PokedexService>();
        builder.Services.AddScoped<IPokemonDatabase, PokemonDatabase>();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        
        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.MapControllers();
        app.UseAuthorization();
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}