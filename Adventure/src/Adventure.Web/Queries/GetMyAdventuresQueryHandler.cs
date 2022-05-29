using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Queries;

public class GetMyAdventuresQueryHandler : IRequestHandler<GetMyAdventuresQuery, IEnumerable<UserAdventureDto>>
{
  private readonly IRepository<UserAdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public GetMyAdventuresQueryHandler(IRepository<UserAdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<UserAdventureDto>> Handle(GetMyAdventuresQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _adventureRepository.ListAsync(d => d.UserId == request.UserId, cancellationToken);
    return _mapper.Map<IEnumerable<UserAdventureDto>>(result);
  }
}
