using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Queries;

public record GetMyAdventuresQuery(int UserId) : IRequest<IEnumerable<UserAdventureDto>>;
