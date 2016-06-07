using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UGTUTelephone.Startup))]
namespace UGTUTelephone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
