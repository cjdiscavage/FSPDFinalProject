using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSPDFinalProject.Startup))]
namespace FSPDFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
