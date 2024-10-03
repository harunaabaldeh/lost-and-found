using API.Common.Extensions;
using API.Domain.Entities;
using API.Features.LostDocument.Commands.CreateLostDocument.Contracts;
using API.Infrastructure.Persistence;

namespace API.Features.LostDocument.Commands.CreateLostDocument;

public class CreateLostDocumentEndpoint : IEndpoint
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPost("api/documents", HandleAsync)
            .WithName("CreateLostDocument")
            .WithTags("LostDocuments");
    }

    public async Task<IResult> HandleAsync(CreateLostDocumentRequest lostDocumentRequest, LostDocumentsContext context)
    {
        var lostDocument = new Domain.Entities.LostDocument
        {
            Type = lostDocumentRequest.Type,
            Number = lostDocumentRequest.Number,
            OwnerName = lostDocumentRequest.OwnerName,
            OwnerContact = lostDocumentRequest.OwnerContact,
            LostDate = lostDocumentRequest.LostDate,
            Status = lostDocumentRequest.Status,
            Description = lostDocumentRequest.Description,
            PlaceFound = lostDocumentRequest.PlaceFound,
            CreatedAt = DateTime.UtcNow
        };

        await context.LostDocuments.AddAsync(lostDocument);

        await context.SaveChangesAsync();

        return Results.Ok(lostDocument);
    }
}