using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Youtube.Startup))]
namespace Youtube
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
