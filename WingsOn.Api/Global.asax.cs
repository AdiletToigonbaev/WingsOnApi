using System.Web.Http;
using WingsOn.Api.App_Start;
using WingsOn.Dal;
using WingsOn.Domain;
using WingsOn.BLL.Services;
using WingsOn.BLL.Interfaces;
using WingsOn.BLL.Mapping;

namespace WingsOn.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Init();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
