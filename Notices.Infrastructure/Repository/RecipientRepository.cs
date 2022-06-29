using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notices.Infrastructure.Context;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Exceptions;

namespace Notices.Infrastructure.Repository;

public class RecipientRepository : IRecipientRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<RecipientRepository> _logger;
    public RecipientRepository(MainContext mainContext, ILogger<RecipientRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
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
        _logger.LogError("Cannot find landlord with provided id: {RecipientId}",id);
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