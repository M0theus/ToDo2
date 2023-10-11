using System.Data;
using FluentValidation;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);

        RuleFor(c => c.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(c => c.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);
    }
}