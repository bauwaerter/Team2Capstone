using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team2Capstone.Startup))]
namespace Team2Capstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
