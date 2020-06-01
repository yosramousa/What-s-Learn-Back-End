using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ITI.WhatsLearn.Presentation.Startup))]

namespace ITI.WhatsLearn.Presentation
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
