using FluentValidation.Results;
using ToDo.Domain.Validation;

namespace ToDo.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    //EF
    public virtual List<AssignmentList> AssignmentLists { get; set; } = new();
    public virtual List<Assignment> Assignments { get; set; } = new();
    
    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new UserValidator().Validate(this);
        return validationResult.IsValid;
    }
}