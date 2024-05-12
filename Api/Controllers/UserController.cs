using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult GetUserInfo()
        {
            return Ok(new { name = "jim" });
        }
    }
}
