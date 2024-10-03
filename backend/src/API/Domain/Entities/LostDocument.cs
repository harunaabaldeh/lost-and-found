using API.Domain.Enums;

namespace API.Domain.Entities;

public class LostDocument
{
  public int Id { get; set; }
  public string Type { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
  public string OwnerName { get; set; } = string.Empty;
  public string OwnerContact { get; set; } = string.Empty;
  public DateTime LostDate { get; set; }
  public Status Status { get; set; }
  public string Description { get; set; } = string.Empty;
  public string PlaceFound { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}