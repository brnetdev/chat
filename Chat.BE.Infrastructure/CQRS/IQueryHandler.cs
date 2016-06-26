using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Infrastructure.CQRS
{
    public interface IQueryHandler<in TParameter, out TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        TResult Handle(TParameter query);
    }
}
