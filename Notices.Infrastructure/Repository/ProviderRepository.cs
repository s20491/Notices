using Microsoft.EntityFrameworkCore;
using Notices.Infrastructure.Context;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Exceptions;

namespace Notices.Infrastructure.Repository;

public class ProviderRepository : IProviderRepository
{
    private readonly MainContext _mainContext;

    public ProviderRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Provider>> GetAll()
    {
        var providers = await _mainContext.Provider.ToListAsync();

        foreach (var provider in providers)
        {
            await _mainContext.Entry(provider).Reference(x => x.Notice).LoadAsync();
        }

        return providers;
    }

    public async Task<Provider> GetById(int id)
    {
        var provider = await _mainContext.Provider.SingleOrDefaultAsync(x => x.Id == id);
        if (provider != null)
        {
            await _mainContext.Entry(provider).Reference(x => x.Notice).LoadAsync();
            return provider;
        }

        throw new EntityNotFoundException();
    }

    public async Task Add(Provider entity)
    {
        var provider = await _mainContext.Provider.SingleOrDefaultAsync(x => x.Notice == entity.Notice);

        if (provider != null)
        {
            throw new EntityAlreadyExistException();
        }

        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Provider entity)
    {
        var providerToUpdate = await _mainContext.Provider.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (providerToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        providerToUpdate.Account = entity.Account;
        providerToUpdate.Notice = entity.Notice;
        providerToUpdate.DateOfUpdate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var providerToDelete = await _mainContext.Provider.SingleOrDefaultAsync(x => x.Id == id);
        if (providerToDelete != null)
        {
            _mainContext.Provider.Remove(providerToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}