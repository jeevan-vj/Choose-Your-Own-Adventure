using Adventure.Core.Models;
using Adventure.Web.ApiModels;
using Adventure.Web.Commands;
using Adventure.Web.Validations;
using FluentAssertions;
using Xunit;

namespace Adventure.UnitTests.Web.Handlers;

public class CreateUserAdventureCommandValidatorTests
{
  [Fact]
  public void validate_return_errors_when_no_selected_option_in_choice()
  {
    var validator = new CreateUserAdventureCommandValidator();
    var adventure = new AdventureDto
    {
      Title = "Adventure 1",
      Choice = new Choice("ch1", "1") {Options = new List<Option> {new("o2", new Choice("ch2", "2"), "1")}}
    };
    var validationResult = validator.Validate(new CreateUserAdventureCommand(){Adventure = adventure, UserId = 1});
    validationResult.Errors.Should().NotBeEmpty();
  }
}
