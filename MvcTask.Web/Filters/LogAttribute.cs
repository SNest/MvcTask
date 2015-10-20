namespace MvcTask.Web.Filters
{
    using System.Web.Mvc;

    using NLog;

    public class LogAttribute : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public LogAttribute(ILogger logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var eventInfo = new LogEventInfo(LogLevel.Info, this.logger.Name,
                filterContext.Controller.GetType().Name + "." + filterContext.ActionDescriptor.ActionName);
            this.logger.Log(eventInfo);
        }
    }
}
