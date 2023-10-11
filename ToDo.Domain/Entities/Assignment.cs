using FluentValidation.Results;
using ToDo.Domain.Validation;

namespace ToDo.Domain.Entities;

public class Assignment : Entity
{
    public int UserId { get; set; }
    public int AssignmentListId { get; set; }
    public string Description { get; set; } = null!;
    public bool Conclued { get; set; }
    public DateTime ConcludedAt { get; set; }
    public DateTime DeadLine { get; set; }
    
    //EF
    public virtual User User { get; set; } = null!;
    public virtual AssignmentList AssignmentList { get; set; } = null!;

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new AssignmentValidator().Validate(this);
        return validationResult.IsValid;
    }
}