using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Chat.BE.Infrastructure.CQRS;

namespace Chat.BE.Domain.Config
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                .BasedOn(typeof(IQueryHandler<,>))
                .WithService.AllInterfaces()
                .Configure(c => c.LifestyleTransient()));

            container.Register(AllTypes.FromThisAssembly()
                .BasedOn(typeof(ICommandHandler<>))
                .WithService.AllInterfaces()
                .Configure(c => c.LifestyleTransient()));
        }
    }
}
