using Microsoft.Owin;
using Owin;
using Ultra.Web;

[assembly: OwinStartup(typeof (Startup))]

namespace Ultra.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}