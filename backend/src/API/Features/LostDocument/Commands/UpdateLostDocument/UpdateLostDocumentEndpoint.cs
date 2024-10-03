using API.Common.Extensions;
using API.Features.LostDocument.Commands.UpdateLostDocument.Contracts;
using API.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace API.Features.LostDocument.Commands.UpdateLostDocument;

public class UpdateLostDocumentEndpoint : IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/documents/{id}", HandleAsync)
            .WithName("UpdateLostDocument")
            .WithTags("LostDocuments");
    }

    public async Task<IResult> HandleAsync(int id, UpdateLostDocumentRequest lostDocumentRequest, LostDocumentsContext context)
    {
        var lostDocument = await context.LostDocuments
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (lostDocument == null) return Results.NotFound("Document not found");

        // TODO: Update document
        lostDocument.Type = lostDocumentRequest.Type;
        lostDocument.Number = lostDocumentRequest.Number;
        lostDocument.OwnerName = lostDocumentRequest.OwnerName;
        lostDocument.OwnerContact = lostDocumentRequest.OwnerContact;
        lostDocument.LostDate = lostDocumentRequest.LostDate;
        lostDocument.Status = lostDocumentRequest.Status;
        lostDocument.Description = lostDocumentRequest.Description;

        context.LostDocuments.Update(lostDocument);

        await context.SaveChangesAsync();

        return Results.Ok(lostDocument);
    }
}