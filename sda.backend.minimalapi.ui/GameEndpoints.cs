using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Services;
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

        routes.MapPost("/api/Game/", (Game model) =>
        {
            //return Results.Created($"/api/Games/{model.ID}", model);
        })
        .WithName("CreateGame")
        .Produces<Game>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Game/{id}", (int id) =>
        {
            //return Results.Ok(new Game { ID = id });
        })
        .WithName("DeleteGame")
        .Produces<Game>(StatusCodes.Status200OK);
    }
}
