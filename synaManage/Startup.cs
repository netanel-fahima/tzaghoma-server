using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(synaManage.Startup))]
namespace synaManage
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            
        

        }


    }
}
