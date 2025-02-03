using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult AddTwoNumbers(int num1, int num2)
        {
            int sum = num1 + num2;
            return Ok($"The sum is {sum}");
        }
    }
}
