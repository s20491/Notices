using Microsoft.AspNetCore.Mvc;
using Notices.Core.DTO;
using Notices.Core.Services;
using Notices.Infrastructure.Exceptions;

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
        try
        {
            await _recipientService.CreateNewRecipientAccountAsync(dto);
        }
        catch (EntityAlreadyExistException)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateRecipient([FromBody] RecipientCreationRequestDto dto, int id)
    {
        try
        {
            await _recipientService.UpdateExistingRecipient(id,dto);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }

        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipient(int id)
    {
        try
        {
            await _recipientService.DeleteRecipient(id);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }

        return Ok();
    }
}