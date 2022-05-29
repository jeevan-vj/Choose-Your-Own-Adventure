using Adventure.Core.Exceptions;
using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Commands;

public class CreateAdventureCommandHandler : IRequestHandler<CreateAdventureCommand, AdventureDto>
{
  private readonly IRepository<AdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public CreateAdventureCommandHandler(IRepository<AdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<AdventureDto> Handle(CreateAdventureCommand request, CancellationToken cancellationToken)
  {
    if (request.Adventure == null) { throw new AdventureDomainException("Adventure Object is required"); }

    var adventureItem = _mapper.Map<AdventureItem>(request.Adventure);
    var result = await _adventureRepository.AddAsync(adventureItem, cancellationToken);
    return _mapper.Map<AdventureDto>(result);
  }
}
