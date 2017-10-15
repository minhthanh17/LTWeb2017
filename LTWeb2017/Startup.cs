using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LTWeb2017.Startup))]
namespace LTWeb2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
