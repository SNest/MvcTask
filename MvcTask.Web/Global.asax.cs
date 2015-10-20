namespace MvcTask.Web
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper;

    using MvcTask.Application.Utils;
    using MvcTask.Web.Infrastructure.Mapping;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ApplicationMappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });
        }
    }
}