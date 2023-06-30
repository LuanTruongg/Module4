using Microsoft.AspNetCore.Mvc;
using Module4.Filter;

namespace Module4.Controllers
{
    [ResponseHeader("Filter-Header", "Filter Value")]
    public class ResponseHeaderController : Controller
    {
        public IActionResult Index()
        {
            //Content("Examine the response headers using the F12 developer tools.");
            return Ok();
        }
        [ResponseHeader("Another-Filter-Header", "Another Filter Value")]
        public IActionResult Multiple() =>
        Content("Examine the response headers using the F12 developer tools.");
    }
}
