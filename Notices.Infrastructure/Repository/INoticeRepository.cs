using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public interface INoticeRepository : IRepository<Notice>
{
    Task AssignRecipientToNotice(int noticeId, int recipientId);
}