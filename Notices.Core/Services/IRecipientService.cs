using Notices.Core.DTO;

namespace Notices.Core.Services;

public interface IRecipientService
{
    Task CreateNewRecipientAccountAsync(RecipientCreationRequestDto dto);

}