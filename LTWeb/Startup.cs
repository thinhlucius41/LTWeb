using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LTWeb.Startup))]
namespace LTWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
