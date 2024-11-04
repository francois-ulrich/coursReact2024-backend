using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OpenApi;
using sda.backend.minimalapi.Core.Auth.Interfaces;
using sda.backend.minimalapi.Core.Auth.Models;
namespace sda.backend.minimalapi.ui;

public static class LoginUserEndpoints
{
    public static void MapLoginUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth/login").WithTags(nameof(LoginUser));

        group.MapPost("/", async (LoginUser model, UserManager<AuthenticationUser> userManager, ITokenService tokenService, HttpContext httpContext) =>
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
            httpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddMinutes(30),
            });

            result = TypedResults.Ok(new
            {
                Email = model.Login,
                Username = user.UserName,
            });

            return result;
        })
        .WithName("CreateLoginUser")

        .WithOpenApi();
    }
}
