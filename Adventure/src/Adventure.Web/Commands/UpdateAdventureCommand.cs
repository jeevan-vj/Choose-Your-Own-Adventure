using Adventure.Web.ApiModels;
using MediatR;

namespace Adventure.Web.Commands;

public record UpdateAdventureCommand(AdventureDto Adventure) : IRequest<AdventureDto>;
