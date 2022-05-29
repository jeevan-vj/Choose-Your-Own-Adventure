using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Queries;

public record GetAllAdventuresQuery : IRequest<IEnumerable<AdventureDto>>;
