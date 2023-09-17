using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A111.Startup))]
namespace A111
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
