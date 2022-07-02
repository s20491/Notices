namespace Notices.Core.DTO;

public class NoticeCreationRequestDto
{
    public decimal Salary { get; set; }
    public string Description { get; set; }
    public int TypesOfTileSize { get; set; }
    public int TileSize { get; set; }
    public int SquareMeters { get; set; }
    public bool IsWalkIn { get; set; }
    public bool IsLinearDrain { get; set; }
    public bool IsMixerForConcealedInstallation { get; set; }
    public bool IsBidet { get; set; }
    public bool IsFlushMountedFrameWc { get; set; }
    public string Street { get; set; }
    public string? ApartmentNumber { get; set; }
    public string BuildingNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public int ProviderId { get; set; }
}