using Microsoft.AspNetCore.Mvc;
using SoberDinner.Contracts.Menus;

namespace SoberDinner.API.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        [HttpPost]
        public IActionResult CreateMenu(
            CreateMenuRequest request,
            string hostId)
        {
            return Ok(request);
        }
    }
}
