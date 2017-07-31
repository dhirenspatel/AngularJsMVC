using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJsWithMVC.Startup))]
namespace AngularJsWithMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
