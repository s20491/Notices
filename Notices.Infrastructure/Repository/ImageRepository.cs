using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public class ImageRepository : IImageRepository
{
    public Task<IEnumerable<Image>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}