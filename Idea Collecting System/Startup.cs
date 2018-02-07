using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Idea_Collecting_System.Startup))]
namespace Idea_Collecting_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
