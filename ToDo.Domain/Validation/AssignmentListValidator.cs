using System.Data;
using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validation;

public class AssignmentListValidator : AbstractValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);
    }
}