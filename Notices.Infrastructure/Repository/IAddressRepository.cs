using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public interface IAddressRepository : IRepository<Address>
{
    Task<int> GetAddressIdByItsAttributesAsync(string country, string city, string zipCode, string street,
        string buildingNumber, string apartmentNumber);

    Task<Address> CreateAndGetAsync(Address address);
}