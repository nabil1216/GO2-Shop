using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartPOS.App.Startup))]
namespace SmartPOS.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
