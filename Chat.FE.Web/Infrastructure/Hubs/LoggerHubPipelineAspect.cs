using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.FE.Web.Infrastructure.Hubs
{
    public class LoggerHubPipelineAspect : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            Debug.WriteLine($"Wywoluje {context.MethodDescriptor.Hub.Name}.{context.MethodDescriptor.Name}");
            return base.OnBeforeIncoming(context);
        }

        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
            Debug.WriteLine($"Wywoluje klienckie {context.Invocation.Hub}.{context.Invocation.Method}");            
            return base.OnBeforeOutgoing(context);
        }
    }
}
