using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Primeiro_MVC.Startup))]
namespace Primeiro_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
