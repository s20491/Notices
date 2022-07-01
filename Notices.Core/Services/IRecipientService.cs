using Notices.Core.DTO;

namespace Notices.Core.Services;

public interface IRecipientService
{
    Task CreateNewRecipientAccountAsync(RecipientCreationRequestDto dto);
    
    Task UpdateExistingRecipient(int id, RecipientCreationRequestDto dto);
    
    Task DeleteRecipient(int id);

}