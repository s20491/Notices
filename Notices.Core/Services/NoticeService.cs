using Notices.Core.DTO;
using Notices.Infrastructure.Entities;
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
    
    public async Task AddNewNoticeToExistingRecipientAsync(NoticeCreationRequestDto dto)
    {
        var recipient = await _recipientRepository.GetById(dto.RecipientId);

        var addressId = await _addressService.GetAddressIdOrCreateAsync(dto.City,
            dto.City, dto.ZipCode, dto.Street, dto.BuildingNumber, dto.ApartmentNumber);

        await _noticeRepository.Add(new Notice
        {
            AddressId = addressId,
            RecipientId = recipient.Id,
            Salary = dto.Salary,
            Description = dto.Description,
            TypesOfTileSize = dto.TypesOfTileSize,
            TileSize = dto.TileSize,
            SquareMeters = dto.SquareMeters,
            IsWalkIn = dto.IsWalkIn,
            IsLinearDrain = dto.IsLinearDrain,
            IsMixerForConcealedInstallation = dto.IsMixerForConcealedInstallation,
            IsBidet = dto.IsBidet,
            IsFlushMountedFrameWc = dto.IsFlushMountedFrameWc,
        });
    }

    public async Task<NoticeBasicInformationResponseDto> GetMostExpensiveNoticeAsync()
    {
        var notices = await _noticeRepository.GetAll();

        var mostExpensive = notices.MaxBy(x => x.Salary);

        if (mostExpensive is null) return null;

        return new NoticeBasicInformationResponseDto(
            mostExpensive.Salary,
            mostExpensive.Description,
            mostExpensive.TypesOfTileSize,
            mostExpensive.TileSize,
            mostExpensive.SquareMeters,
            mostExpensive.IsWalkIn,
            mostExpensive.IsLinearDrain,
            mostExpensive.IsMixerForConcealedInstallation,
            mostExpensive.IsBidet,
            mostExpensive.IsFlushMountedFrameWc,
            mostExpensive.Address.Street,
            mostExpensive.Address.ApartmentNumber,
            mostExpensive.Address.BuildingNumber,
            mostExpensive.Address.ZipCode,
            mostExpensive.Address.City
        );
    }
}