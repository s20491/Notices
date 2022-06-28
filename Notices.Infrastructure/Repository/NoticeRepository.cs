using Microsoft.EntityFrameworkCore;
using Notices.Infrastructure.Context;
using Notices.Infrastructure.Entities;
using Notices.Infrastructure.Exceptions;

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

    public async Task<Notice> GetById(int id)
    {
        var notice = await _mainContext.Notice.SingleOrDefaultAsync(x => x.Id == id);
        if (notice != null)
        {
            await _mainContext.Entry(notice).Reference(x => x.Address).LoadAsync();
            return notice;
        }else {
            throw new EntityNotFoundException();
        }
    }

    public async Task Add(Notice entity)
    {
        var notice = await _mainContext.Notice.SingleOrDefaultAsync(x => x.Address == entity.Address);
        if (notice != null)
        {
            throw new EntityAlreadyExistException();
        }
        
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Notice entity)
    {
        var noticeToUpdate = await _mainContext.Notice.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (noticeToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        noticeToUpdate.Salary = entity.Salary;
        noticeToUpdate.Description = entity.Description;
        noticeToUpdate.TypesOfTileSize = entity.TypesOfTileSize;
        noticeToUpdate.TileSize = entity.TileSize;
        noticeToUpdate.SquareMeters = entity.SquareMeters;
        noticeToUpdate.IsWalkIn = entity.IsWalkIn;
        noticeToUpdate.IsWalkIn = entity.IsWalkIn;
        noticeToUpdate.IsLinearDrain = entity.IsLinearDrain;
        noticeToUpdate.IsMixerForConcealedInstallation = entity.IsMixerForConcealedInstallation;
        noticeToUpdate.IsBidet = entity.IsBidet;
        noticeToUpdate.IsFlushMountedFrameWc = entity.IsFlushMountedFrameWc;
        noticeToUpdate.DateOfUpdate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var noticeToDelete = await _mainContext.Notice.SingleOrDefaultAsync(x => x.Id == id);
        if (noticeToDelete != null)
        {
            _mainContext.Notice.Remove(noticeToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}