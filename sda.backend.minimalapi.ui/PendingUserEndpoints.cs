using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Auth.Models;
namespace sda.backend.minimalapi.ui;

public static class PendingUserEndpoints
{
    public static void MapPendingUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth/register").WithTags(nameof(PendingUser));

        group.MapPost("/", async (PendingUser model, UserManager<AuthenticationUser> userManager) =>
        {
            IResult result = TypedResults.BadRequest();

            //return TypedResults.Created($"/api/PendingUsers/{model.ID}", model);
            var pendingUserResult = await userManager.CreateAsync(new AuthenticationUser()
            {
                UserName = model.UserName,
                Id = model.Email,
                Email= model.Email,
            }, model.Password);

            if (pendingUserResult.Succeeded)
            {
                result = TypedResults.Created("/api/auth/register", model);
            }

            return result;
        })
        .WithName("CreatePendingUser")
        .WithOpenApi();
    }
}
