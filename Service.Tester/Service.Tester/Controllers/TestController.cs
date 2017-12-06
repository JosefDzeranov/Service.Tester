using Microsoft.AspNetCore.Mvc;

namespace Service.Tester.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Get()
        {
            return Ok("Yes!!!");
        }
    }
}
