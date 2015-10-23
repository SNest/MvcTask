namespace MvcTask.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Create", 
                "{controller}/new",
                new { action = "Create" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
                "Edit", 
                "{controller}/update",
                new { action = "Edit" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
                "Game",
                "{controller}/{gamekey}/{action}",
                new { action = "Details" },
                new { controller = "Game" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
                "Publisher",
                "{controller}/{companyname}/{action}",
                new { action = "Details" },
                new { controller = "Publisher" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Game", action = "Index", id = UrlParameter.Optional })
                .DataTokens.Add("area", "Common");
        }
    }
}