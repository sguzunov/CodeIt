using Microsoft.Owin;
using Owin;

using CodeIt.Web.Config;

[assembly: OwinStartup(typeof(CodeIt.Web.Startup))]
namespace CodeIt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AuthConfig.Configure(app);
        }
    }
}
