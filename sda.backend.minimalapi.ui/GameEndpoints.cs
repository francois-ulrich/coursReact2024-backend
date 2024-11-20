using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Games.Services.Models;
using Microsoft.AspNetCore.Builder;

namespace sda.backend.minimalapi.ui;

public static class GameEndpoints
{
    public static void MapGameEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Game", (IGetAllGamesService service) =>
        {
            return service.GetAll();
        })
        .WithName("GetAllGames")
        .RequireAuthorization()
        .Produces<Game[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/Game/{id}", async (int id, GameDbContext db) =>
        {
            var game = await db.Games.FindAsync(id);

            if (game != null)
                return Results.Ok(game);

            return Results.NotFound();
        })
        .WithName("GetGameById")
        .RequireAuthorization()
        .Produces<Game>(StatusCodes.Status200OK);

        routes.MapPost("/api/Game/", async (GameDto gameDto, GameDbContext db) =>
        {
            var game = new Game
            {
                Name = gameDto.Name,
                CharacterName = gameDto.CharacterName,
                Success = gameDto.Success,
                DateStart = gameDto.DateStart,
                DateEnd = gameDto.DateEnd
            };

            db.Games.Add(game);
            await db.SaveChangesAsync();

            return Results.Created($"/api/Games/{game.Id}", game);
        })
        .WithName("CreateGame")
        .RequireAuthorization()
        .Produces<Game>(StatusCodes.Status201Created);

        routes.MapPut("/api/Game/{id}", async (int id, GameDto gameDto, GameDbContext db) =>
        {
            var game = await db.Games.FindAsync(id);

            if (game == null)
                return Results.NotFound();

            game.Name = gameDto.Name;
            game.CharacterName = gameDto.CharacterName;
            game.Success = gameDto.Success;
            game.DateStart = gameDto.DateStart;
            game.DateEnd = gameDto.DateEnd;

            await db.SaveChangesAsync();
            return Results.Ok(game);
        })
        .WithName("UpdateGame")
        .RequireAuthorization()
        .Produces(StatusCodes.Status204NoContent);

        routes.MapDelete("/api/Game/{id}", async (int id, GameDbContext db) =>
        {
            var game = await db.Games.FindAsync(id);

            if (game == null)
                return Results.NotFound();

            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return Results.NoContent();
        })
        .WithName("DeleteGame")
        .RequireAuthorization()
        .Produces<Game>(StatusCodes.Status200OK);
    }
}
