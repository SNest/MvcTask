namespace MvcTask.Web.Areas.Common
{
    using System.Web.Mvc;

    public class CommonAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Common";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "Common_default",
            //    "{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //).DataTokens.Add("area", "Common");
        }
    }
}
