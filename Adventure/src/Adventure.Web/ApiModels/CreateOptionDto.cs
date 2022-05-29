namespace Adventure.Web.ApiModels;

public record CreateOptionDto
{
  public string Title { get; init; }
  public CreateChoiceDto? Next { get; init; }
}
