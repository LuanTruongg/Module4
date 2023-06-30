using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Module4.Models;

namespace Module4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configutarion;
        private readonly IOptions<PositionOptions> _options;

        //public PositionOption? positionOptions { get; private set; }

        public HomeController(IConfiguration configuration, IOptions<PositionOptions> options)
        {
            _configutarion = configuration;   
            _options = options;
        }
        public IActionResult Index()
        {
            //positionOptions = _configutarion.GetSection(PositionOption.Position)
            //                                        .Get<PositionOption>();
            //return Content($"Title: {positionOptions.Title} \n" +
            //          $"Name: {positionOptions.Name}");
            return Ok();
        }
        public IActionResult Index2()
        {
            return Content($"Title: {_options.Value.Title} \n" +
                      $"Name: {_options.Value.Name}");
        }
    }
}
