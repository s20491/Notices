using Microsoft.AspNetCore.Mvc;
using Notices.Core.DTO;
using Notices.Core.Services;
using Notices.Infrastructure.Exceptions;

namespace Notices.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProviderController : ControllerBase
{
    private readonly IProviderService _providerService;
    
    public ProviderController(IProviderService providerService)
    {
        _providerService = providerService;
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewProvider([FromBody] ProviderCreationRequestDto dto)
    {
        try
        {
            await _providerService.CreateNewProviderAccountAsync(dto);
        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }

        return Ok();
    }
}