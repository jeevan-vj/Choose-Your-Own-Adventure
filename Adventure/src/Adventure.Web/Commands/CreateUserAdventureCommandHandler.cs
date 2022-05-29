using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using AutoMapper;
using MediatR;

namespace Adventure.Web.Commands;

public class CreateUserAdventureCommandHandler : IRequestHandler<CreateUserAdventureCommand, UserAdventureDto>
{
  private readonly IRepository<UserAdventureItem> _adventureRepository;
  private readonly IMapper _mapper;

  public CreateUserAdventureCommandHandler(IRepository<UserAdventureItem> adventureRepository, IMapper mapper)
  {
    _adventureRepository = adventureRepository;
    _mapper = mapper;
  }

  public async Task<UserAdventureDto> Handle(CreateUserAdventureCommand request, CancellationToken cancellationToken)
  {
    var adventureItem = _mapper.Map<AdventureItem>(request.Adventure);
    var userAdventureItem = new UserAdventureItem {Adventure = adventureItem, UserId = request.UserId};
    var result = await _adventureRepository.AddAsync(userAdventureItem, cancellationToken);
    var resultDto = _mapper.Map<UserAdventureDto>(result);
    return resultDto;
  }
}
