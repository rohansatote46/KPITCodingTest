using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPITEmployeeProject.Startup))]
namespace KPITEmployeeProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
