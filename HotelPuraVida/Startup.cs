using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelPuraVida.Startup))]
namespace HotelPuraVida
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
