namespace API.Features.Authentication.Commands.Register.Contracts;

public class RegisterRequest
{
    public string FullName { get; set; }
    public string Address { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}