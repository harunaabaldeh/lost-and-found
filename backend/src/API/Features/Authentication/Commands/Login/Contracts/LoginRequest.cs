namespace API.Features.Authentication.Commands.Login.Contracts;

public class LoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}