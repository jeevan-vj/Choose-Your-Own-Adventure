using Adventure.Web.Commands;
using FluentValidation;

namespace Adventure.Web.Validations;

public class UpdateAdventureCommandValidator : AbstractValidator<UpdateAdventureCommand>
{
  public UpdateAdventureCommandValidator(ILogger<UpdateAdventureCommandValidator> logger)
  {
    RuleFor(command => command.Adventure.Id).NotEmpty().WithMessage("Adventure Id is required");
    RuleFor(command => command.Adventure.Title).NotEmpty().WithMessage("Title is required");
    RuleFor(command => command.Adventure.Choice).NotNull().WithMessage("No Choice found");
  }
}
