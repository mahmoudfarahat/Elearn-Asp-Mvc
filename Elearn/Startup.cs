using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Elearn.Startup))]
namespace Elearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
