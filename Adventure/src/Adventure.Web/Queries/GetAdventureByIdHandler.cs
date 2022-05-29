using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Queries;

public class GetAdventureByIdHandler : IRequestHandler<GetAdventureByIdQuery, AdventureDto>
{
  private readonly IRepository<AdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public GetAdventureByIdHandler(IRepository<AdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<AdventureDto> Handle(GetAdventureByIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _adventureRepository.GetByIdAsync(request.Id, cancellationToken);
    return _mapper.Map<AdventureDto>(result);
  }
}
