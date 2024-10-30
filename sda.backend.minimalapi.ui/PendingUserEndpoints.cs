using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Auth.Models;
namespace sda.backend.minimalapi.ui;

public static class PendingUserEndpoints
{
    public static void MapPendingUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/PendingUser").WithTags(nameof(PendingUser));

        group.MapGet("/", () =>
        {
            return new [] { new PendingUser() };
        })
        .WithName("GetAllPendingUsers")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new PendingUser { ID = id };
        })
        .WithName("GetPendingUserById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, PendingUser input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdatePendingUser")
        .WithOpenApi();

        group.MapPost("/", (PendingUser model) =>
        {
            //return TypedResults.Created($"/api/PendingUsers/{model.ID}", model);
        })
        .WithName("CreatePendingUser")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new PendingUser { ID = id });
        })
        .WithName("DeletePendingUser")
        .WithOpenApi();
    }
}
