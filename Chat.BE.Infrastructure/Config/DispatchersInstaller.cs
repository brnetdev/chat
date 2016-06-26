using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;

namespace Chat.BE.Infrastructure.Config
{
    public class DispatchersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IQueryDispatcher>().ImplementedBy<QueryDispatcher>().LifestyleTransient());
            container.Register(Component.For<ICommandDispatcher>().ImplementedBy<CommandDispatcher>().LifestyleTransient());
        }
    }
}
