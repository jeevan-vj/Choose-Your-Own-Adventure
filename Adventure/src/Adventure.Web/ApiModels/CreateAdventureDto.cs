namespace Adventure.Web.ApiModels;

public record CreateAdventureDto
{
  public string? Title { get; init; }

  public CreateChoiceDto Choice { get; init; }
}
