using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HW1_1.Startup))]
namespace HW1_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
