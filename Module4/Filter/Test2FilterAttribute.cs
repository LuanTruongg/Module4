using Microsoft.AspNetCore.Mvc.Filters;

namespace Module4.Filter
{
    public class Test2FilterAttribute : Attribute, IActionFilter
    {
        private readonly string _name;
        public Test2FilterAttribute(string name)
        {
            _name = name;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{_name} Hello from Test2Filter OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{_name} Hello from Test2Filter OnActionExecuting");
        }
    }
}
