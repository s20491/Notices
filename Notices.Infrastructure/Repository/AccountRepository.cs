using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public class AccountRepository : IAccountRepository
{
    public Task<IEnumerable<Account>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Account entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Account entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}