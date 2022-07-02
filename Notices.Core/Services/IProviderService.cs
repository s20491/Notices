using Notices.Core.DTO;

namespace Notices.Core.Services;

public interface IProviderService
{
    Task CreateNewProviderAccountAsync(ProviderCreationRequestDto dto);
}