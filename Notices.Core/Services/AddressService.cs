using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Repository;

namespace Notices.Core.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<int> GetAddressIdOrCreateAsync(string country, string city, string zipCode, string street,
        string buildingNumber, string apartmentNumber)
    {
        var id = await _addressRepository.GetAddressIdByItsAttributesAsync(country, city, zipCode, street,
            buildingNumber,
            apartmentNumber);

        if (id != 0) return id;

        var address = await _addressRepository.CreateAndGetAsync(new Address
        {
            Country = country,
            City = city,
            ZipCode = zipCode,
            Street = street,
            BuildingNumber = buildingNumber,
            ApartmentNumber = apartmentNumber
        });

        return address.Id;
    }
}