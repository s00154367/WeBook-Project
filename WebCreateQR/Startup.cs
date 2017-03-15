using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCreateQR.Startup))]
namespace WebCreateQR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
