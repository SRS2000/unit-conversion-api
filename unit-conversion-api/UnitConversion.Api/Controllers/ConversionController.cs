using Microsoft.AspNetCore.Mvc;
using UnitConversion.Application.DTOs;
using UnitConversion.Application.Interfaces;

namespace UnitConversion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionController(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    /// <summary>
    /// Convert a value from one unit to another.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ConversionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Convert([FromBody] ConversionRequest request)
    {
        var response = await _conversionService.ConvertAsync(request);

        return Ok(response);
    }
}