using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repository;

public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(ApplicationDbContext context) : base(context)
    { }

    public async Task<Assignment?> GetById(int id, int userId)
    {
        return await Context.Assignments
            .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public void Add(Assignment assignment)
    {
        Context.Assignments.Add(assignment);
    }

    public void Edit(Assignment assignment)
    {
        Context.Assignments.Update(assignment);
    }

    public void Delete(Assignment assignment)
    {
        Context.Assignments.Remove(assignment);
    }
}