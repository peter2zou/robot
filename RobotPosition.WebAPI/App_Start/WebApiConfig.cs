using System.Web.Http;
using Microsoft.Practices.Unity;
using RobotPosition.Service;
using RobotPosition.DataAccess;

namespace RobotPosition.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetGridId",
                routeTemplate: "{controller}"
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{gridId}/rover",
                defaults: new { gridId = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IRobotPositionService, RobotPositionService>();
            container.RegisterType<IDataService, DataService>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
