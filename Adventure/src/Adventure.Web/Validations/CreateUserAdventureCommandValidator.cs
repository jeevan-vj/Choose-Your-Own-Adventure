using Adventure.Core.Models;
using Adventure.Web.Commands;
using FluentValidation;

namespace Adventure.Web.Validations;

public class CreateUserAdventureCommandValidator : AbstractValidator<CreateUserAdventureCommand>
{
  public CreateUserAdventureCommandValidator()
  {
    RuleFor(command => command.Adventure).NotNull().WithMessage("No Adventure Object found");
    RuleFor(command => command.UserId).NotNull().GreaterThan(0).WithMessage("User Id is required to create my adventures.");
    RuleFor(command => command.Adventure.Title).NotEmpty().WithMessage("Title is required");
    RuleFor(command => command.Adventure.Choice).NotNull().WithMessage("No Choice found");
    RuleFor(command => command.Adventure.Choice.SelectedOptionId).NotNull().WithMessage("A Option should be selected");
    RuleFor(command => command.Adventure.Choice).Must(IsValid)
      .WithMessage("Invalid data selection.Please select correct option for Choice.SelectedOptionId");
  }

  private bool IsValid(Choice choice)
  {
    var isValid = true;
    var selectedOption = choice?.Options?.Where(o => o.Id == choice.SelectedOptionId).FirstOrDefault();
    if (selectedOption == null)
    {
      return false;
    }

    while (true)
    {
      if (selectedOption != null)
      {
        isValid = IsValidChoice(selectedOption.Next);
        if (!isValid)
        {
          break;
        }
      }

      if (string.IsNullOrEmpty(selectedOption.Next.SelectedOptionId))
      {
        break;
      }


      selectedOption = selectedOption?.Next?.Options.First(o => o.Id == selectedOption.Next.SelectedOptionId);
    }

    return isValid;
  }

  private static bool IsValidChoice(Choice choice)
  {
    if ((string.IsNullOrEmpty(choice.SelectedOptionId) && choice.Options == null) || choice.Options?.Count == 0)
    {
      return true;
    }

    return string.IsNullOrEmpty(choice.SelectedOptionId) || choice.Options.Any(c =>
      string.Equals(c.Id, choice.SelectedOptionId, StringComparison.Ordinal));
  }
}
