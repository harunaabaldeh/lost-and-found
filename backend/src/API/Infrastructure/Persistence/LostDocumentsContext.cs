using API.Domain.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Persistence;

public class LostDocumentsContext : IdentityDbContext<AppUser>
{
    public LostDocumentsContext(DbContextOptions<LostDocumentsContext> options) : base(options)
    {
    }

    public DbSet<LostDocument> LostDocuments { get; set; }
}