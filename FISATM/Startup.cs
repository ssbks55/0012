using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FISATM.Startup))]
namespace FISATM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
