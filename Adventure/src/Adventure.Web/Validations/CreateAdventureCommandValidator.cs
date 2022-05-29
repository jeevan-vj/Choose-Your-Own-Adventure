using Adventure.Web.Commands;
using FluentValidation;

namespace Adventure.Web.Validations;

public class CreateAdventureCommandValidator : AbstractValidator<CreateAdventureCommand>
{
  public CreateAdventureCommandValidator()
  {
    RuleFor(command => command.Adventure).NotNull().WithMessage("No Adventure Object found");
    RuleFor(command => command.Adventure.Title).NotEmpty().WithMessage("Title is required");
    RuleFor(command => command.Adventure.Choice).NotNull().WithMessage("No Choice found");
  }
}
