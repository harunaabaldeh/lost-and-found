using API.Common.Services;
using API.Domain.Entities;
using API.Features.Authentication.Commands.Login.Contracts;

namespace API.Features.Authentication.Services;

public class UserService
{
    private readonly TokenService _tokenService;
    public UserService(TokenService tokenService)
    {
        _tokenService = tokenService;
    }
    public LoginResponse CreateUser(AppUser user)
    {
        return new LoginResponse
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }
}