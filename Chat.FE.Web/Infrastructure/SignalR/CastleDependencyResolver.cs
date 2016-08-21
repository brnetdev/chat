using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Infrastructure.SignalR
{
    public class CastleDependencyResolver : Microsoft.AspNet.SignalR.DefaultDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public CastleDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("Container");
            }
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            if (_container.Kernel.HasComponent(serviceType))
            {
                return _container.Resolve(serviceType);
            }
            return base.GetService(serviceType);
            
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            //IEnumerable<object> objects;

            //if (_container.Kernel.HasComponent(serviceType))
            //{
            //    objects = _container.ResolveAll(serviceType).Cast<object>();
            //}
            //else
            //{
            //    objecdt
            //}
            return _container.ResolveAll(serviceType).Cast<object>().ToList().Concat(base.GetServices(serviceType));
        }


    }
}
