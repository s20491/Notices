using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account> CreateAndGet(Account account);
}