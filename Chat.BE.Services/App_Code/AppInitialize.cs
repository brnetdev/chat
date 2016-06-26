using Castle.Facilities.WcfIntegration;
using Castle.Facilities.TypedFactory.Internal;
using Castle.Windsor;
using Chat.BE.Domain.Config;
using Chat.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.BE.Infrastructure.Config;
using Chat.BE.Services.Config;

namespace Chat.BE.Services.App_Code
{
    public static class AppInitialization
    {
        public static void AppInitialize()
        {
            var container = new WindsorContainer();
            container.AddFacility(new WcfFacility());            
            container.Install(new DomainInstaller(), new DispatchersInstaller(), new WcfInstaller());
            QueueManager.CreateQueues();
        }
    }
}
