using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Queries;

public class GetAllAdventuresQueryHandler : IRequestHandler<GetAllAdventuresQuery, IEnumerable<AdventureDto>>
{
  private readonly IRepository<AdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public GetAllAdventuresQueryHandler(IRepository<AdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<AdventureDto>> Handle(GetAllAdventuresQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _adventureRepository.ListAsync(cancellationToken);
    return _mapper.Map<IEnumerable<AdventureDto>>(result);
  }
}
