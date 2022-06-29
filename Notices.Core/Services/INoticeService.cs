using Notices.Core.DTO;

namespace Notices.Core.Services;

public interface INoticeService
{
    Task<IEnumerable<NoticeBasicInformationResponseDto>> GetAllNoticesBasicInfoAsync();

    Task AddNewNoticeToExistingRecipientAsync(NoticeCreationRequestDto dto);

    Task<NoticeBasicInformationResponseDto> GetMostExpensiveNoticeAsync();
}