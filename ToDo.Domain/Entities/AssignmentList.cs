using FluentValidation.Results;
using ToDo.Domain.Validation;

namespace ToDo.Domain.Entities;

public class AssignmentList : Entity
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    
    //EF
    public virtual User User { get; set; } = null!;
    public virtual List<Assignment> Assignments { get; set; } = new();

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new AssignmentListValidator().Validate(this);
        return validationResult.IsValid;
    }
}