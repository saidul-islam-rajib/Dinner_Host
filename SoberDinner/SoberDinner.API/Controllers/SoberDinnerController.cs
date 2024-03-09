using Microsoft.AspNetCore.Mvc;

namespace SoberDinner.API.Controllers
{
    [Route("[controller]")]
    
    public class SoberDinnerController : ApiController
    {
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
