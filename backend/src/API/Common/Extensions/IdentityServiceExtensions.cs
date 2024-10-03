using System.Text;

using API.Common.Services;
using API.Domain.Entities;
using API.Features.Authentication.Services;
using API.Infrastructure.Persistence;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Common.Extensions;

public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<AppUser>(opt =>
      {
          opt.Password.RequireNonAlphanumeric = false;
      })
        .AddEntityFrameworkStores<LostDocumentsContext>()
        .AddSignInManager<SignInManager<AppUser>>();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key here aiming for 12 characters!!"));

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(opt =>
                        {
                            opt.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = key,
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                        });

        builder.Services.AddScoped<TokenService>();
        builder.Services.AddScoped<UserService>();
    }
}