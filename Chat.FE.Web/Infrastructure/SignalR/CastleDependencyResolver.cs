using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Chat.FE.Web.Infrastructure.SignalR
{
    public class CastleDependencyResolver : Microsoft.AspNet.SignalR.DefaultDependencyResolver, System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
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

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
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

    internal sealed class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;            
            //_scope = container.BeginScope();
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
