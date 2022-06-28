using Microsoft.EntityFrameworkCore;
using Notices.Infrastructure.Context;
using Notices.Infrastructure.Entities;

namespace Notices.Infrastructure.Repository;

public class NoticeRepository : INoticeRepository
{
    private readonly MainContext _mainContext;

    public NoticeRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Notice>> GetAll()
    {
        var notices = await _mainContext.Notice.ToListAsync();

        foreach (var notice in notices)
        {
            await _mainContext.Entry(notice).Reference(x => x.Address).LoadAsync();
        }

        return notices;
    }

    public Task<Notice> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Notice entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Notice entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}