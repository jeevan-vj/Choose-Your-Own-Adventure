namespace Adventure.Web.ApiModels;

public record UserAdventureDto
{
  public string? Id { get; init; }

  public AdventureDto Adventure { get; init; }
}
