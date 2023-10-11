using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validation;

public class AssignmentValidator : AbstractValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);

        RuleFor(c => c.DeadLine)
            .GreaterThan(DateTime.Now);

    }
}