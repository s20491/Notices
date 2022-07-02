using Notices.Core.DTO;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Repository;

namespace Notices.Core.Services;

public class ProviderService : IProviderService
{
    private readonly IProviderRepository _providerRepository;
    private readonly IAccountRepository _accountRepository;
    
    
    
    public ProviderService(IProviderRepository providerRepository, IAccountRepository accountRepository)
    {
        _providerRepository = providerRepository;
        _accountRepository = accountRepository;
    }


    public async Task CreateNewProviderAccountAsync(ProviderCreationRequestDto dto)
    {
        var account = await _accountRepository.CreateAndGet(new Account
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            IsAccountActive = true,
        });

        await _providerRepository.Add(new Provider
        {
            Notice = null,
            AccountId = account.Id
        });
    }
}