using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(devMeet.Startup))]
namespace devMeet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
