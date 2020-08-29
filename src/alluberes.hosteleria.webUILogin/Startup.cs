using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(alluberes.hosteleria.webUILogin.Startup))]
namespace alluberes.hosteleria.webUILogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
