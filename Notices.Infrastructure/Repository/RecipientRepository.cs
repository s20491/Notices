using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public class RecipientRepository : IRecipientRepository
{
    public Task<IEnumerable<Recipient>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Recipient> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Recipient entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Recipient entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}