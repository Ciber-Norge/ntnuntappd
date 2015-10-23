using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CiBeer.Startup))]
namespace CiBeer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
