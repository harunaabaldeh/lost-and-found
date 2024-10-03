using API.Common.Extensions;
using API.Domain.Entities;
using API.Features.Authentication.Commands.Register.Contracts;
using API.Features.Authentication.Services;
using API.Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Authentication.Commands.Register
{
    public class RegisterEndpoint : IEndpoint
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/auth/register", HandleAsync)
                .WithName("Register")
                .WithTags("Authentication");
        }

        public async Task<IResult> HandleAsync(RegisterRequest registerRequest,
                                               UserService userService,
                                               UserManager<AppUser> userManager,
                                               LostDocumentsContext context)
        {
            if (await userManager.Users.AnyAsync(u => u.UserName == registerRequest.Username))
                return Results.BadRequest("username already exist");


            if (await userManager.Users.AnyAsync(u => u.Email == registerRequest.Email))
                return Results.BadRequest("email already exist");

            var newUser = new AppUser
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                FullName = registerRequest.FullName,
                Address = registerRequest.Address
            };

            var result = await userManager.CreateAsync(newUser, registerRequest.Password);

            if (result.Succeeded)
            {
                var response = userService.CreateUser(newUser);
                return Results.Ok(response);
            }

            return Results.BadRequest("There was a problem registering user");
        }
    }
}