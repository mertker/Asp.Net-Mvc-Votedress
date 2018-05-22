using Microsoft.Owin;
using Owin;


namespace Votedress.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }

    }
}