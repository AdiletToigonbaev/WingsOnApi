using System.Net.Http.Headers;
using System.Web.Http;
using WingsOn.Api.App_Start;
using WingsOn.Dal;
using WingsOn.Domain;
using WingsOn.BLL.Interfaces;
using WingsOn.BLL.Services;
using Unity;
using Unity.Lifetime;
using WingsOn.BLL.Mapping;
using WingsOn.Api.Models;
using WingsOn.BLL.DTOs;

namespace WingsOn.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IRepository<Person>, PersonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IFlightService, FlightService>();
            container.RegisterType<IBookingService, BookingService>();
            AutoMapperConfig.RegisterInstance(container);
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Filters.Add(new NotImplExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
        }

    }
}
