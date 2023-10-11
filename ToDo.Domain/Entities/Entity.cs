using FluentValidation.Results;
using ToDo.Domain.Contracts;

namespace ToDo.Domain.Entities;

public class Entity : IEntity
{
    public int Id { get; set; }

    public virtual bool Validar(out  ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}