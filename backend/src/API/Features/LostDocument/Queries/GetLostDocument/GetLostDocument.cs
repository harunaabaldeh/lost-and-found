using API.Common.Extensions;
using API.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace API.Features.LostDocument.Queries.GetLostDocument;

public class GetLostDocument : IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/documents/{id}", HandleAsync)
            .WithName("GetLostDocument")
            .WithTags("LostDocuments");
    }

    public async Task<IResult> HandleAsync(int id, LostDocumentsContext context)
    {
        var lostDocument = await context.LostDocuments
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        return Results.Ok(lostDocument);
    }
}