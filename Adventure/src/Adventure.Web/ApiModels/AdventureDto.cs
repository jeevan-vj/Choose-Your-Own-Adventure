using Adventure.Core.Models;

namespace Adventure.Web.ApiModels;

public record AdventureDto
{
  public string? Title { get; init; }

  public Choice Choice { get; init; } = null!;

  public string? Id { get; init; }
}
