using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeIt.Web.Startup))]
namespace CodeIt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
