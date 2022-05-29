using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Queries;

public record GetMyAdventureByIdQuery(string Id) : IRequest<AdventureDto>;
