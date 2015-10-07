using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NTNUntappd.Startup))]
namespace NTNUntappd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
