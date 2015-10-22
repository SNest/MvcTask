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
               "PublisherBase",
               "{controller}/{companyName}",
               new { action = "Details" },
               new { controller = "Publisher" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
              "PublisherNew",
              "{controller}/new",
              new { action = "Create" },
              new { controller = "Publisher" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
              "GameNew",
              "{controller}/new",
              new { action = "Create" },
              new { controller = "Game" }).DataTokens.Add("area", "Common");

            routes.MapRoute(
              "GameUpdate",
              "{controller}/update",
              new { action = "Edit" },
              new { controller = "Game" }).DataTokens.Add("area", "Common"); 

            routes.MapRoute(
                "GameBase",
                "{controller}/{gameKey}/{action}",
                new { action = "Details" },
                new { controller = "Game" }).DataTokens.Add("area", "Common"); ;

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional })
                .DataTokens.Add("area", "Common");
        }
    }
}