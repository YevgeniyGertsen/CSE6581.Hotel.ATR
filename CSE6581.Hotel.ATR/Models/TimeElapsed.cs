using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Models
{
    public class TimeElapsed : Attribute, IActionFilter
    {
        private Stopwatch timer;
        private readonly ILogger<TimeElapsed> _logger;
        public TimeElapsed()
        {

        }
        public TimeElapsed(ILogger<TimeElapsed> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();

            string result = "ElapsedTime: " +
                            $"{timer.ElapsedMilliseconds} ms";

            string actionName = context.ActionDescriptor.DisplayName;
            string controler = "Home";
            //_logger.LogInformation("метод действия = {actionName} {ElapsedTime}", actionName, timer.ElapsedMilliseconds);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
            
        }
    }
}
