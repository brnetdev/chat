using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chat.BE.Contracts.Proxies;

namespace Chat.BE.Contracts.Config
{
    public class ProxiesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRoomService, RoomServiceProxy>().LifeStyle.Transient);
        }
    }
}
