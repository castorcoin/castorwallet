using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CastorCoinUsingdemo.Startup))]
namespace CastorCoinUsingdemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
