using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Chat.FE.Web.App_Start
{
    public class IocConfig
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

            _container.Install();
            //container.Register
        }

        public static void ReleaseContainer()
        {
            _container.Dispose();
        }
    }
}
