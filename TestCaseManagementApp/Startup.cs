using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestCaseManagementApp.Startup))]
namespace TestCaseManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
