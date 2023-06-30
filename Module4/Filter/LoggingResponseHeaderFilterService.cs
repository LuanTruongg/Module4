using Microsoft.AspNetCore.Mvc.Filters;

namespace Module4.Filter
{
    public class LoggingResponseHeaderFilterService : IResultFilter
    {
        private readonly ILogger _logger;
        public LoggingResponseHeaderFilterService(ILogger<LoggingResponseHeaderFilterService> logger)
        {

            _logger = logger;

        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation(
           $"- {nameof(LoggingResponseHeaderFilterService)}.{nameof(OnResultExecuted)}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation(
           $"- {nameof(LoggingResponseHeaderFilterService)}.{nameof(OnResultExecuting)}");

            context.HttpContext.Response.Headers.Add(
                nameof(OnResultExecuting), nameof(LoggingResponseHeaderFilterService));
        }
    }
}
