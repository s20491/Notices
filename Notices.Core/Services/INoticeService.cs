using Notices.Core.DTO;

namespace Notices.Core.Services;

public interface INoticeService
{
    Task<IEnumerable<NoticeBasicInformationResponseDto>> GetAllNoticesBasicInfoAsync();

    Task CreateNewNotice(NoticeCreationRequestDto dto);
    Task AddNewNoticeToExistingRecipientAsync(AddNoticeToRecipient dto);

    Task<NoticeBasicInformationResponseDto> GetMostExpensiveNoticeAsync();
    
    Task UpdateExistingNotice(int id, NoticeBasicInformationResponseDto dto);
    Task DeleteNotice(int id);
    
}