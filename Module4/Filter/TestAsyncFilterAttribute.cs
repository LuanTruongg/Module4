using Microsoft.AspNetCore.Mvc.Filters;

namespace Module4.Filter
{
    public class TestAsyncFilterAttribute : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        private readonly string _name;

        public int Order { get; set; }

        public TestAsyncFilterAttribute(string name, int order = 0)
        {
            _name = name;
            Order = order;

        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"{_name} - Hello from Test Async Filter BEFORE Action Execution ");
            await next();
            Console.WriteLine($"{_name} - Hello from Test Async Filter ANTER Action Execution ");
        }
    }
}
