namespace Notices.Infrastructure.Entities;

public class Image : BaseEntity
{
    public byte[] Data { get; set; }

    public int ApartmentId { get; set; }
    public Notice Notice { get; set; }
}