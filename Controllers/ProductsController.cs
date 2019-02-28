using Microsoft.AspNetCore.Mvc;

namespace AngularProj.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Greetings() {
            return Ok("Hello from ASP.NET Core Web API.");
        }
    }
}