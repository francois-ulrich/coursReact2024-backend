using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Games.Services.Models;

namespace sda.backend.minimalapi.ui;


public static class GameEndpoints
{
    public static void MapGameEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Game", (IGetAllGamesService service) =>
        {
            return service.GetAll();
        })
        .WithName("GetAllGames")
        .RequireAuthorization()
        .Produces<Game[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/Game/{id}", (int id) =>
        {
            //return new Game { ID = id };
        })
        .WithName("GetGameById")
        .Produces<Game>(StatusCodes.Status200OK);

        routes.MapPut("/api/Game/{id}", (int id, Game input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateGame")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Game/", async (Game game, GameDbContext db) =>
        {
            db.Games.Add(game);
            await db.SaveChangesAsync();

            return Results.Created($"/api/Games/{game.Id}", game);
        })
        .WithName("CreateGame")
        .RequireAuthorization()
        .Produces<Game>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Game/{id}", (int id) =>
        {
            //return Results.Ok(new Game { ID = id });
        })
        .WithName("DeleteGame")
        .Produces<Game>(StatusCodes.Status200OK);
    }
}
