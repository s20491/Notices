using Microsoft.EntityFrameworkCore;
using Notices.Infrastructure.Context;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Exceptions;

namespace Notices.Infrastructure.Repository;

public class RecipientRepository : IRecipientRepository
{
    private readonly MainContext _mainContext;
    
    public RecipientRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task<IEnumerable<Recipient>> GetAll()
    {
        var recipients = await _mainContext.Recipient.ToListAsync();

        foreach (var recipient in recipients)
        {
            await _mainContext.Entry(recipient).Reference(x => x.Notices).LoadAsync();
        }

        return recipients;
    }

    public async Task<Recipient> GetById(int id)
    {
        var recipient = await _mainContext.Recipient.SingleOrDefaultAsync(x => x.Id == id);
        if (recipient != null)
        {
            await _mainContext.Entry(recipient).Reference(x => x.Notices).LoadAsync();
            await _mainContext.Entry(recipient).Collection(x => x.Notices).LoadAsync();
            return recipient;
        }
        throw new EntityNotFoundException();
    }

    public async Task Add(Recipient entity)
    {
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Recipient entity)
    {
        var landlordToUpdate = await _mainContext.Recipient.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (landlordToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        landlordToUpdate.Account = entity.Account;
        landlordToUpdate.Notices = entity.Notices;
        landlordToUpdate.DateOfUpdate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var recipientToDelete = await _mainContext.Recipient.SingleOrDefaultAsync(x => x.Id == id);
        if (recipientToDelete != null)
        {
            _mainContext.Recipient.Remove(recipientToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}