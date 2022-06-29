using Notices.Core.DTO;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Repository;

namespace Notices.Core.Services;

public class RecipientService : IRecipientService
{
    private readonly IRecipientRepository _recipientRepository;
    private readonly IAccountRepository _accountRepository;

    public RecipientService(IRecipientRepository recipientRepository,
        IAccountRepository accountRepository)
    {
        _recipientRepository = recipientRepository;
        _accountRepository = accountRepository;
    }

    public async Task CreateNewRecipientAccountAsync(RecipientCreationRequestDto dto)
    {
        
        var account = await _accountRepository.CreateAndGet(new Account
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            IsAccountActive = true,
        });

        await _recipientRepository.Add(new Recipient
        {
            AccountId = account.Id
        });
    }
}