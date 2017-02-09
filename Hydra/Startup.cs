using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hydra.Startup))]
namespace Hydra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
