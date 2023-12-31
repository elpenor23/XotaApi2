using Microsoft.AspNetCore.Mvc;
using XotaApi2.Models;
using XotaApi2.Managers;

namespace XotaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XotaItemsController : ControllerBase
{
    private IConfiguration Configuration;

    public XotaItemsController(IConfiguration configuration){
        Configuration = configuration;
    }

    // GET: api/XotaItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IXotaItem>>> GetXotaItem()
    {
        List<IXotaItem> data = new List<IXotaItem>();

        XotaDataManager XM = new XotaDataManager(Configuration);

        data = await XM.GetXotaItems();

        if (data.Count == 0) return NotFound();

        return Ok(data);
    }
}
