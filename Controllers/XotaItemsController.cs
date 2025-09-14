using Microsoft.AspNetCore.Mvc;
using XotaApi2.Models;
using XotaApi2.Managers;

namespace XotaApi2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XotaItemsController(IXotaDataManager dataManager) : ControllerBase
{
    // GET: api/XotaItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<XotaItem>>> GetXotaItem()
    {
        var data = await dataManager.GetXotaItems();

        if (data.Count == 0) return NotFound();

        return Ok(data);
    }

    [HttpGet("test/pota")]
    public async Task<ActionResult> TestPota()
    {
        var x = await dataManager.TestPota();
        return Ok(x);
    }

    [HttpGet("test/sota")]
    public async Task<ActionResult> TestSota()
    {
        var x = await dataManager.TestSota();
        return Ok(x);
    }

    [HttpGet("test/radar")]
    public async Task<ActionResult> TestRadar()
    {
        var x = await dataManager.TestRadar();
        return Ok(x);
    }
}
