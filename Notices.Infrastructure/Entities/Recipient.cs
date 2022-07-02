namespace Notices.Infrastructure.Entities;

public class Recipient : BaseEntity
{
    public IEnumerable<Notice> Notices { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }
}