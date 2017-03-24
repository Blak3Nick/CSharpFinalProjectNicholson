using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerTracking.Startup))]
namespace CustomerTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
