using BlueMedia.Models;
using BlueMedia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlueMedia.Controllers;

[ApiController]
public class BlueMediaController : ControllerBase
{
    private readonly IBlueMediaService _service;

    public BlueMediaController(IBlueMediaService service)
    {
        _service = service;
    }

    [HttpPost("status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/x-www-form-urlencoded")]
    public IActionResult GetStatus([FromForm] IFormCollection data)
    {
        _service.UpdateStatus(data);
        return Ok();
    }
    
    [HttpPost("url")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUrl([FromForm] UrlDto urlDto)
    {
        var transactionUrl = await _service.GetUrlAsync(urlDto.Amount);
        return Ok(transactionUrl);
    }
}