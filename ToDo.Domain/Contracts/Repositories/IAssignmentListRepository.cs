using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories;

public interface IAssignmentListRepository : IRepository<AssignmentList>
{
    Task<AssignmentList?> GetById(int id, int userId);
    Task<AssignmentList?> GetByIdWithAssignments(int id, int userId);
    void Add(AssignmentList assignmentList);
    void Edit(AssignmentList assignmentList);
    void Delete(AssignmentList assignmentList);
}