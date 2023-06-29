using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Xml.Linq;

namespace Module4.Filter
{
    public class ShortCircuitingResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //Console.WriteLine(" Hello from ShortCircuitingResourceFilterAttribute ");
            context.Result = new ContentResult
            {
                Content = " Hello from ShortCircuitingResourceFilterAttribute "
            };
        }
    }
}
