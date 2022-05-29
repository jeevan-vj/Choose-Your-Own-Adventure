using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Queries;

public record GetAdventureByIdQuery(string Id) : IRequest<AdventureDto>;
