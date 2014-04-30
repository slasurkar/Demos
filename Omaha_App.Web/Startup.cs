using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Omaha_App.Web.Startup))]
namespace Omaha_App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
