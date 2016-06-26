using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Infrastructure.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IKernel _kernel;

        public CommandDispatcher(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IStatusResult Execute<TCommand>(TCommand command)
            where TCommand : ICommand            
        {
            var handler = _kernel.Resolve<ICommandHandler<TCommand>>();
            return handler.Handle(command);
        }
    }
}
