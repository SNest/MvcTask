namespace MvcTask.Web.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;

    using NLog;

    public class LogTimeAttribute : ActionFilterAttribute
    {
        private Stopwatch watch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.watch = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.watch.Stop();
            var logger = LogManager.GetCurrentClassLogger();
            var eventInfo = new LogEventInfo(LogLevel.Trace, logger.Name, "Service request time: " + this.watch.ElapsedMilliseconds + "ms");
            eventInfo.Properties["action"] = filterContext.ActionDescriptor.ActionName;
            eventInfo.Properties["controller"] = filterContext.Controller.GetType().Name;
            logger.Log(eventInfo);
        }
    }
}
