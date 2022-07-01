using Microsoft.AspNetCore.Mvc;
using Notices.Core.DTO;
using Notices.Core.Services;

namespace Notices.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipientController : ControllerBase
{
    private readonly IRecipientService _recipientService;

    public RecipientController(IRecipientService recipientService)
    {
        _recipientService = recipientService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewRecipientAccount([FromBody] RecipientCreationRequestDto dto)
    {
        await _recipientService.CreateNewRecipientAccountAsync(dto);
        return NoContent();
    }
}