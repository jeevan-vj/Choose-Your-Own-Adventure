namespace Adventure.Web.ApiModels;

public record CreateChoiceDto
{
  public string Title { get; init; }
  public IEnumerable<CreateOptionDto>? Options { get; set; }
}
