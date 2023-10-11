using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    void Add(User user);
    Task<User?> FindEmail(string email);
    Task<bool> EmailInUse(string email);
}