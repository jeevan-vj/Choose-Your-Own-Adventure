using Adventure.Core.Exceptions;
using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Commands;

public class UpdateAdventureCommandHandler : IRequestHandler<UpdateAdventureCommand, AdventureDto>
{
  private readonly IRepository<AdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public UpdateAdventureCommandHandler(IRepository<AdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<AdventureDto> Handle(UpdateAdventureCommand request, CancellationToken cancellationToken)
  {
    var existingItem = await _adventureRepository.GetByIdAsync(request.Adventure.Id, cancellationToken);
    if (existingItem == null)
    {
      throw new AdventureDomainException("Adventure Not Found");
    }

    var adventureItem = _mapper.Map<AdventureItem>(request.Adventure);
    var result = await _adventureRepository.AddAsync(adventureItem, cancellationToken);
    var resultDto = _mapper.Map<AdventureDto>(result);
    return resultDto;
  }
}
