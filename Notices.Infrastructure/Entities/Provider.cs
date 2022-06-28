namespace Notices.Infrastructure.Entities;

public class Provider : BaseEntity
{
    public Notice Notice { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }
}