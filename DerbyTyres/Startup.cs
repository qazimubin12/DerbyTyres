using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DerbyTyres.Startup))]
namespace DerbyTyres
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
    }
}
