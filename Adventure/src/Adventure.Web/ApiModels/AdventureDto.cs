using Adventure.Core.Models;

namespace Adventure.Web.ApiModels;

public record AdventureDto
{
  public string? Title { get; init; }

  public Choice Choice { get; init; } = null!;

  public string? Id { get; init; }
}

public record CreateAdventureDto
{
  public string? Title { get; init; }

  public CreateChoiceDto Choice { get; init; }
}

public record CreateChoiceDto
{
  public string Title { get; init; }
  public IEnumerable<CreateOptionDto>? Options { get; set; }
}

public record CreateOptionDto
{
  public string Title { get; init; }
  public CreateChoiceDto Next { get; init; }
}
