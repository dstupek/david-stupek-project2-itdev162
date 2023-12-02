using Microsoft.AspNetCore.Mvc.Filters;

namespace WebStoreApi.Filters
{
    public class StatsFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            DateTime reference = new DateTime(2023, 02, 12);
            TimeSpan time = DateTime.Now - reference;
            Console.WriteLine("[Stats Filter] OnActionExecuting - Time=" + time.TotalMilliseconds + "ms");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            DateTime reference = new DateTime(2023, 02, 12);
            TimeSpan time = DateTime.Now - reference;
            Console.WriteLine("[Stats Filter] OnActionExecuted - Time=" + time.TotalMilliseconds + "ms");
        }

    }
}
