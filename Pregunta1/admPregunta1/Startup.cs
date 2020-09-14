using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admPregunta1.Startup))]
namespace admPregunta1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
