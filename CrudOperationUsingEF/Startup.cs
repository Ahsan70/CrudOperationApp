using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudOperationUsingEF.Startup))]
namespace CrudOperationUsingEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
