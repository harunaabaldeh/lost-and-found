using API.Common.Extensions;
using API.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace API.Features.LostDocument.Commands.DeleteLostDocument;


public class DeleteLostDocumentEndpoint : IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/documents/{id}", HandleAsync)
            .WithName("DeleteLostDocument")
            .WithTags("LostDocuments");
    }

    public async Task<IResult> HandleAsync(int id, LostDocumentsContext context)
    {
        var lostDocument = await context.LostDocuments
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (lostDocument == null) return Results.NotFound("Document not found.");

        context.LostDocuments.Remove(lostDocument);

        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
