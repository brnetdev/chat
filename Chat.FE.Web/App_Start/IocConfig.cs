using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Chat.FE.Web.Infrastructure.Common;
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
            _container.Register(Classes.FromThisAssembly()
                                 .BasedOn<IController>()
                                 .LifestyleTransient());
            _container.Register(Component.For<IContextDataProvider>().ImplementedBy<ContextDataProvider>().LifestylePerWebRequest());            
        }

        public static void ReleaseContainer()
        {
            _container.Dispose();
        }        
    }
}
