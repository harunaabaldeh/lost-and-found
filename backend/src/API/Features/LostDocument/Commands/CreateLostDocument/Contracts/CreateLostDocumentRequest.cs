using API.Domain.Enums;

namespace API.Features.LostDocument.Commands.CreateLostDocument.Contracts;

public class CreateLostDocumentRequest
{
    public required string Type { get; set; }
    public required string Number { get; set; }
    public required string OwnerName { get; set; }
    public required string OwnerContact { get; set; }
    public required DateTime LostDate { get; set; }
    public required Status Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public required string PlaceFound { get; set; }
}