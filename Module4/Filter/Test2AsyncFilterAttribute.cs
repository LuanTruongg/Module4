using Microsoft.AspNetCore.Mvc.Filters;

namespace Module4.Filter
{
    public class Test2AsyncFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;
        public Test2AsyncFilterAttribute(string name)
        {
            _name = name;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"{_name} - Hello from Test 2 Async Filter BEFORE Action Execution ");
            await next();
            Console.WriteLine($"{_name} - Hello from Test 2 Async Filter ANTER Action Execution ");
        }
    }
}
