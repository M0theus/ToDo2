using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repository;

public class AssignmentListRepository : Repository<AssignmentList>, IAssignmentListRepository
{
    public AssignmentListRepository(ApplicationDbContext context) : base(context)
    { }

    public async Task<AssignmentList?> GetById(int id, int userId)
    {
        return await Context.AssignmentLists
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public async Task<AssignmentList?> GetByIdWithAssignments(int id, int userId)
    {
        return await Context.AssignmentLists
            .Include(c => c.Assignments)
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public void Add(AssignmentList assignmentList)
    {
        Context.AssignmentLists.Add(assignmentList);
    }

    public void Edit(AssignmentList assignmentList)
    {
        Context.AssignmentLists.Update(assignmentList);
    }

    public void Delete(AssignmentList assignmentList)
    {
        Context.AssignmentLists.Remove(assignmentList);
    }
}