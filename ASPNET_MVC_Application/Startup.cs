using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNET_MVC_Application.Startup))]
namespace ASPNET_MVC_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
