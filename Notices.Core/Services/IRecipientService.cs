using Notices.Core.DTO;

namespace Notices.Core.Services;

public class IRecipientService
{
    Task CreateNewRecipientAccountAsync(RecipientCreationRequestDto dto);

}