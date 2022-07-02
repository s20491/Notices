namespace Notices.Core.DTO;

public class AddNoticeToRecipient
{
    public int NoticeId { get; set; }
    public int RecipientId { get; set; }

    public AddNoticeToRecipient(int noticeId, int recipientId)
    {
        NoticeId = noticeId;
        RecipientId = recipientId;
    }
}