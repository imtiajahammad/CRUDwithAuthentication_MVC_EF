using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDwithAuthentication_MVC_EF.Startup))]
namespace CRUDwithAuthentication_MVC_EF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
