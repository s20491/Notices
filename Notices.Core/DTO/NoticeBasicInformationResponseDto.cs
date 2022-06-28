namespace Notices.Core.DTO;

public class NoticeBasicInformationResponseDto
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

    public NoticeBasicInformationResponseDto(decimal salary, string description, int typesOfTileSize,
        int tileSize, int squareMeters, bool isWalkIn, bool isLinearDrain, bool isMixerForConcealedInstallation,
        bool isBidet, bool isFlushMountedFrameWc, string street, string apartmentNumber, string buildingNumber,
        string zipCode)
    {
        Salary = salary;
        Description = description;
        TypesOfTileSize = typesOfTileSize;
        TileSize = tileSize;
        SquareMeters = squareMeters;
        IsWalkIn = isWalkIn;
        IsLinearDrain = isLinearDrain;
        IsMixerForConcealedInstallation = isMixerForConcealedInstallation;
        IsBidet = isBidet;
        IsFlushMountedFrameWc = isFlushMountedFrameWc;
        Street = street;
        ApartmentNumber = apartmentNumber;
        BuildingNumber = buildingNumber;
        ZipCode = zipCode;
    }
}