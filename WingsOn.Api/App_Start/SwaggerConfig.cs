using System.Web.Http;
using WebActivatorEx;
using WingsOn.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WingsOn.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WingsOn.Api");
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }
    }
}