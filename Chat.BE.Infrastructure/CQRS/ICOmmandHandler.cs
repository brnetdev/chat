using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Infrastructure.CQRS
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand        
    {
        IStatusResult Handle(TCommand command);
    }
}
