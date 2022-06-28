using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public class ProviderRepository : IProviderRepository
{
    public Task<IEnumerable<Provider>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Provider> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Provider entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Provider entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}