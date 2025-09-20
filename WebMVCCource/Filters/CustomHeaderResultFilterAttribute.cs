using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVCCource.Filters
{
    public class CustomHeaderResultFilterAttribute : Attribute,IResultFilter
    {
        public static Dictionary<string, int> dict = new Dictionary<string, int>();      
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var controllerName = context.Controller.GetType().Name;
            if (dict.ContainsKey(controllerName))
            {
                dict[controllerName]++;
            }
            else
            {
                dict[controllerName] = 1;
            }
            if (dict.TryGetValue(controllerName, out int count))
                context.HttpContext.Response.Headers["X-Controller-Requests"] =  count.ToString();
        }
    }
}
