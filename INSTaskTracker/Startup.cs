using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INSTaskTracker.Startup))]
namespace INSTaskTracker
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
