using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Auth.Interfaces;
using sda.backend.minimalapi.Core.Auth.Models;
namespace sda.backend.minimalapi.ui;

public static class LoginUserEndpoints
{
    public static void MapLoginUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth/login").WithTags(nameof(LoginUser));

        group.MapPost("/", async (LoginUser model, UserManager<AuthenticationUser> userManager, ITokenService tokenService) =>
        {
            IResult result = Results.BadRequest(new { message = "Invalid username or password" });

            var user = await userManager.FindByEmailAsync(model.Login);

            if (user == null)
                return result;

            var isPasswordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if(!isPasswordValid)
                return result;

            var token = tokenService.Create(user);

            result = TypedResults.Ok(new
            {
                Email = model.Login,
                Token = token,
            });

            return result;
        })
        .WithName("CreateLoginUser")
        .WithOpenApi();
    }
}
