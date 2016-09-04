using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Chat.BE.Contracts;
using Chat.BE.Contracts.Proxies;
using Chat.FE.Web.Infrastructure.Common;
using Microsoft.AspNet.SignalR.Hubs;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Chat.FE.Web.App_Start
{
    public static class IocConfig
    {
        private static Castle.Windsor.WindsorContainer _container = new Castle.Windsor.WindsorContainer();
        
        public static Castle.Windsor.WindsorContainer Container {
            get
            {
                return _container;
            }
        }

        public static void RegisterComponents()
        {
            _container.Register(Classes.FromThisAssembly().BasedOn(typeof(IHub)).LifestyleTransient());

            _container.Register(Classes.FromThisAssembly()
                                 .BasedOn<IController>()
                                 .LifestyleTransient());

            _container.Register(Classes.FromThisAssembly()
                           .BasedOn<IHttpController>()
                           .LifestylePerWebRequest());

            _container.Register(Component.For<IContextDataProvider>().ImplementedBy<ContextDataProvider>().LifestyleTransient());
            _container.Register(Component.For<IRoomService>().ImplementedBy<RoomServiceProxy>());
        }

        public static void ReleaseContainer()
        {
            _container.Dispose();
        }        
    }
}
