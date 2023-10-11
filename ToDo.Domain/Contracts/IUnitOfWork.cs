namespace ToDo.Domain.Contracts;

public interface IUnitOfWork
{
    Task<bool> Commit();
}