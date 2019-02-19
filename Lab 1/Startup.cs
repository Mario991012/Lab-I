using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_1.Startup))]
namespace Lab_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
