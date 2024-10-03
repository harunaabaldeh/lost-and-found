using API.Common.Extensions;
using API.Common.Services;
using API.Domain.Entities;
using API.Features.Authentication.Commands.Login.Contracts;
using API.Features.Authentication.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Authentication.Commands.Login;

public class LoginEndpoint : IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login", HandleAsync)
            .WithName("Login")
            .WithTags("Authentication");
    }

    public async Task<IResult> HandleAsync(LoginRequest loginRequest, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                                           UserService userService)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginRequest.Username);

        if (user is null)
            return Results.Unauthorized();

        var result = await signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

        if (result.Succeeded)
        {
            var response = userService.CreateUser(user);
            return Results.Ok(response);
        }

        return Results.Unauthorized();
    }
}