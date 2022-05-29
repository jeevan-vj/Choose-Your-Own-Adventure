using Adventure.Web.ApiModels;
using Adventure.Web.Commands;
using Adventure.Web.Validations;
using FluentAssertions;
using Xunit;

namespace Adventure.UnitTests.Web.Handlers;

public class CreateAdventureCommandValidatorTest
{
  [Fact]
  public void validate_return_errors_when_no_title_in_adventure()
  {
    var validator = new CreateAdventureCommandValidator();
    var validationResult = validator.Validate(new CreateAdventureCommand(new CreateAdventureDto {Title = null}));
    validationResult.Errors.Should().NotBeEmpty();
    validationResult.Errors.Any(e => e.PropertyName.Contains("Title")).Should().BeTrue();
  }

  [Fact]
  public void validate_return_errors_when_no_parent_choice_in_adventure()
  {
    var validator = new CreateAdventureCommandValidator();
    var validationResult = validator.Validate(new CreateAdventureCommand(new CreateAdventureDto {Title = "Adven1"}));
    validationResult.Errors.Should().NotBeEmpty();
    validationResult.Errors.Any(e => e.PropertyName.Contains("Choice")).Should().BeTrue();
  }
}
