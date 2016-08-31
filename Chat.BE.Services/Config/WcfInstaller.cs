using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using Chat.BE.Contracts;

namespace Chat.BE.Services.Config
{
    public class WcfInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRoomService>().ImplementedBy<RoomService>().Named("Chat.BE.Services.RoomService").LifestylePerWcfOperation());
            container.Register(Component.For<IPeopleOnlineService>().ImplementedBy<PeopleOnlineService>().Named("Chat.BE.Services.PeopleOnlineService").LifestylePerWcfOperation());
        }
    }
}
