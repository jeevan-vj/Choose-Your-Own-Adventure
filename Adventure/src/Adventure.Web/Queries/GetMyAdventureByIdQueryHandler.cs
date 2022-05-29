using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Queries;

public class GetMyAdventureByIdQueryHandler : IRequestHandler<GetMyAdventureByIdQuery, AdventureDto>
{
  private readonly IRepository<UserAdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public GetMyAdventureByIdQueryHandler(IRepository<UserAdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<AdventureDto> Handle(GetMyAdventureByIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _adventureRepository.GetByIdAsync(request.Id, cancellationToken);
    return _mapper.Map<AdventureDto>(result);
  }
}
