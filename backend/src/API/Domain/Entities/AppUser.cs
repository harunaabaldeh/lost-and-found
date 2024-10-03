using Microsoft.AspNetCore.Identity;

namespace API.Domain.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}