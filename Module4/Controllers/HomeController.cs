using Microsoft.AspNetCore.Mvc;

namespace Module4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configutarion;

        public HomeController(IConfiguration configuration)
        {
            _configutarion = configuration;   
        }
        public IActionResult Index()
        {
            var myKeyValue = _configutarion["MyKey"];
            var title = _configutarion["Position:Title"];
            var name = _configutarion["Position:Name"];
            var defaultLogLevel = _configutarion["Logging:LogLevel:Default"];


            return Content($"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Default Log Level: {defaultLogLevel}");
            
        }
    }
}
