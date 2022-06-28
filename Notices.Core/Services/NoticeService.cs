using Notices.Core.DTO;
using Notices.Infrastructure.Repository;

namespace Notices.Core.Services;

public class NoticeService : INoticeService
{
    
    private readonly INoticeRepository _noticeRepository;
    private readonly IRecipientRepository _recipientRepository;
    private readonly IAddressService _addressService;
    
    public NoticeService(INoticeRepository noticeRepository, IRecipientRepository recipientRepository,
        IAddressService addressService)
    {
        _noticeRepository = noticeRepository;
        _recipientRepository = recipientRepository;
        _addressService = addressService;
    }
    
    public async Task<IEnumerable<NoticeBasicInformationResponseDto>> GetAllNoticesBasicInfoAsync()
    {
        var notices = await _noticeRepository.GetAll();

        return notices.Select(x => new NoticeBasicInformationResponseDto(
            x.Salary,
            x.Description,
            x.TypesOfTileSize,
            x.TileSize,
            x.SquareMeters,
            x.IsWalkIn,
            x.IsLinearDrain,
            x.IsMixerForConcealedInstallation,
            x.IsBidet,
            x.IsFlushMountedFrameWc,
            x.Address.Street,
            x.Address.ApartmentNumber,
            x.Address.BuildingNumber,
            x.Address.ZipCode,
            x.Address.City
        ));
    }

    public Task AddNewNoticeToExistingRecipientAsync(NoticeBasicInformationResponseDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<NoticeBasicInformationResponseDto> GetMostExpensiveNoticeAsync()
    {
        throw new NotImplementedException();
    }
}