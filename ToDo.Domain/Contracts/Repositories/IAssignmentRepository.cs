using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories;

public interface IAssignmentRepository : IRepository<Assignment>
{
    Task<Assignment?> GetById(int id, int userId);
    void Add(Assignment assignment);
    void Edit(Assignment assignment);
    void Delete(Assignment assignment);
}