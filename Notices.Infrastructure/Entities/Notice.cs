namespace Notices.Infrastructure.Entities;

public class Notice : BaseEntity
{
    public decimal Salary { get; set; }
    public string Description { get; set; }
    public int TileSize { get; set; }
    public int SquareMeters { get; set; }
    public bool IsWalkIn { get; set; }
    public bool IsLinearDrain { get; set; }
    public bool IsMixerForConcealedInstallation { get; set; }
    public bool IsBidet { get; set; }
    public bool IsFlushMountedFrameWc { get; set; }

    public int ProviderId { get; set; }
    public Provider Provider { get; set; }

    public int? RecipientId { get; set; }
    public Recipient? Recipient { get; set; }

    public int AddressId { get; set; }
    public Address Address { get; set; }

    public IEnumerable<Image> Images { get; set; }
}