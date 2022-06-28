namespace Notices.Infrastructure.Entities;

public class Recipient
{
    public List<Notice> Notices { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }
}