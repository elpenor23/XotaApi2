using Microsoft.AspNetCore.Mvc;
using XotaApi2.Models;
using XotaApi2.Managers;
using System.Net;

namespace XotaApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XotaItemsController(IXotaDataManager dataManager) : ControllerBase
{
    // GET: api/XotaItems
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(IEnumerable<XotaItem>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetXotaItem(int durationMinutes = 24)
    {
        var data = await dataManager.GetXotaItems(durationMinutes);

        if (data is null || !data.Any()) 
            return NoContent();

        return Ok(data);
    }

    [HttpGet("test/pota")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(IEnumerable<XotaItem>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TestPota()
    {
        var data = await dataManager.TestPota();
        return Ok(data);
    }

    [HttpGet("test/sota")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(IEnumerable<XotaItem>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TestSota()
    {
        var data = await dataManager.TestSota();

        if (data is null || !data.Any())
            return NoContent();
            
        return Ok(data);
    }

    [HttpGet("test/radar")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(IEnumerable<XotaItem>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TestRadar()
    {
        var data = await dataManager.TestRadar();

        if (data is null || !data.Any())
            return NoContent();
            
        return Ok(data);
    }
}
