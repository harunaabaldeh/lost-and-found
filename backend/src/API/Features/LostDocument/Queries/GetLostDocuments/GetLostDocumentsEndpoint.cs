using API.Common.Extensions;
using API.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace API.Features.LostDocument.Queries.GetLostDocuments;

public class GetLostDocumentsEndpoint : IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/documents", HandleAsync)
            .WithName("GetLostDocuments")
            .WithTags("LostDocuments");
    }

    public async Task<IResult> HandleAsync(LostDocumentsContext context, string? search)
    {
        var query = context.LostDocuments.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Type.Contains(search) || x.OwnerName.Contains(search));
        }

        var lostDocuments = await query.ToListAsync();

        return Results.Ok(lostDocuments);
    }
}