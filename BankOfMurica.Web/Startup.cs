using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankOfMurica.Web.Startup))]
namespace BankOfMurica.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
