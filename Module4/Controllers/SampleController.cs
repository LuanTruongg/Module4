using Microsoft.AspNetCore.Mvc;
using Module4.Filter;

namespace Module4.Controllers
{
    //[Route("/Sample")]
    [AddHeader("Author", "Steve Smith @ardalis")]
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Examine the headers using developer tools.");
        }

    }
}
