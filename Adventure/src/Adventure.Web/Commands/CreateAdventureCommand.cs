
using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Commands;

public record CreateAdventureCommand(CreateAdventureDto Adventure) : IRequest<AdventureDto>;
