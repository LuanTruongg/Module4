using Microsoft.AspNetCore.Mvc.Filters;

namespace Module4.Filter
{
    public class TestFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Hello from OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Hello from OnActionExecuting");
        }
    }
}
