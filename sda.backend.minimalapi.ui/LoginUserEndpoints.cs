using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Auth.Interfaces;
using sda.backend.minimalapi.Core.Auth.Models;
namespace sda.backend.minimalapi.ui;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth").WithTags(nameof(LoginUser));

        group.MapGet("/me", async (UserManager <AuthenticationUser> userManager, HttpContext httpContext) =>
        {
            var user = await userManager.GetUserAsync(httpContext.User);

            if (user == null)
            {
                return Results.Unauthorized();
            }

            return TypedResults.Ok(new
            {
                Email = user.Email,
                Username = user.UserName,
            });
        })
        .WithName("GetUserInfos")
        .RequireAuthorization()
        .WithOpenApi();

        group.MapPost("/login", async (LoginUser model, UserManager<AuthenticationUser> userManager, ITokenService tokenService, HttpContext httpContext) =>
        {
            IResult result = Results.BadRequest(new { message = "Invalid username or password" });

            var user = await userManager.FindByEmailAsync(model.Login);

            if (user == null)
                return result;


            var isPasswordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
                return result;

            var token = tokenService.Create(user);

            // Créer un cookie HttpOnly pour le token
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddMinutes(75),
            };

            httpContext.Response.Cookies.Append("accessToken", token, cookieOptions);

            result = TypedResults.Ok(new
            {
                Email = user.Email,
                Username = user.UserName,
            });

            return result;
        })
        .WithName("LogInUser")
        .WithOpenApi();


        // Endpoint pour logout
        group.MapPost("/logout", (HttpContext httpContext) =>
        {
            // Supprimer le cookie HttpOnly pour déconnecter l'utilisateur
            httpContext.Response.Cookies.Delete("accessToken");

            return Results.Ok(new { message = "Logged out successfully" });
        })
        .WithName("LogOutUser")
        .WithOpenApi();
    }
}
