using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRManager.Startup))]
namespace HRManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
