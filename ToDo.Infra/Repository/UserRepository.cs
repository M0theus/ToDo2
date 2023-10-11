using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    { }

    public void Add(User user)
    {
        Context.Users.Add(user);
    }

    public async Task<User?> FindEmail(string email)
    {
        return await Context.Users.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<bool> EmailInUse(string email)
    {
        return await Context.Users.AnyAsync(c => c.Email == email);
    }
}