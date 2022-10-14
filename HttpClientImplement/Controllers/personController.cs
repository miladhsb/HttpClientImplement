using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientImplement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personController : ControllerBase
    {
        [HttpGet]
        public ActionResult GET()
        {
            return Ok("ok");
        }
    }
}
