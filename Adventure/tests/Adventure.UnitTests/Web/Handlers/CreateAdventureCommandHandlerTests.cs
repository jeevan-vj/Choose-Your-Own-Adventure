using Adventure.Core.Exceptions;
using Adventure.Core.Models;
using Adventure.Infrastructure.Interfaces;
using Adventure.Web.ApiModels;
using Adventure.Web.Commands;
using Adventure.Web.MappingProfiles;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Adventure.UnitTests.Web.Handlers;

public class CreateAdventureCommandHandlerTests
{
  private readonly IMapper _mapper;
  private readonly IRepository<AdventureItem> _repository;
  private readonly CreateAdventureCommandHandler sut;

  public CreateAdventureCommandHandlerTests()
  {
    _repository = Substitute.For<IRepository<AdventureItem>>();

    var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new AdventureProfile()));
    _mapper = mapperConfiguration.CreateMapper();
    sut = new CreateAdventureCommandHandler(_repository, _mapper);
  }

  [Fact]
  public async void Handle_throws_exception_when_no_adventure()
  {
    var act = () => sut.Handle(new CreateAdventureCommand(null), CancellationToken.None);

    await act.Should().ThrowAsync<AdventureDomainException>();
  }

  [Fact]
  public async void Handle_calls_repository_with_adventure()
  {
    var adventure = new CreateAdventureDto {Title = "Title", Choice = new CreateChoiceDto {Title = "ch1"}};

    Task<AdventureDto> Act()
    {
      return sut.Handle(new CreateAdventureCommand(adventure), CancellationToken.None);
    }

    await Act();
    await _repository.Received().AddAsync(Arg.Any<AdventureItem>(), CancellationToken.None);
  }
}
