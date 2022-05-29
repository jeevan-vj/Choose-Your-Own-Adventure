using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Commands;

public record CreateUserAdventureCommand : IRequest<UserAdventureDto>
{
  public AdventureDto Adventure { get; init; }
  public int UserId { get; set; }
}
