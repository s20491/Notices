using Microsoft.AspNetCore.Mvc;
using Notices.Core.DTO;
using Notices.Core.Services;
using Notices.Infrastructure.Exceptions;

namespace Notices.Controllers;

[ApiController]
[Route("api/notice")]
public class NoticeController : ControllerBase
{
    private readonly INoticeService _noticeService;

    public NoticeController(INoticeService noticeService)
    {
        _noticeService = noticeService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewNotice([FromBody] NoticeCreationRequestDto dto)
    {
        try
        {
            await _noticeService.AddNewNoticeToExistingRecipientAsync(dto);
        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _noticeService.GetAllNoticesBasicInfoAsync());
    }

    [HttpGet("GetTheMostExpensive")]
    public async Task<IActionResult> GetTheMostExpensiveNotice()
    {
        var notice = await _noticeService.GetMostExpensiveNoticeAsync();

        return Ok(notice);
    }
}