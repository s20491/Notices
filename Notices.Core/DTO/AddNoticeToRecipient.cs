namespace Notices.Core.DTO;

public class AddNoticeToRecipient
{
    public int NoticeId;
    public int RecipientId;

    public AddNoticeToRecipient(int noticeId, int recipientId)
    {
        NoticeId = noticeId;
        RecipientId = recipientId;
    }
}