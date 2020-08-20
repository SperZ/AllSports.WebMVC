using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllSports.WebMVC.Startup))]
namespace AllSports.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
