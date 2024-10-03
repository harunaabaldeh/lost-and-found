using API.Domain.Enums;

namespace API.Features.LostDocument.Commands.UpdateLostDocument.Contracts;

public class UpdateLostDocumentRequest
{
    public string Type { get; set; }
    public string Number { get; set; }
    public string OwnerName { get; set; }
    public string OwnerContact { get; set; }
    public DateTime LostDate { get; set; }
    public Status Status { get; set; }
    public string Description { get; set; }
}