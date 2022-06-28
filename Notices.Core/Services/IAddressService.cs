namespace Notices.Core.Services;

public class IAddressService
{
    Task<int> GetAddressIdOrCreateAsync(string city, string zipCode, string street, string
        buildingNumber, string apartmentNumber);
}