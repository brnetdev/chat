using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Chat.Common
{
    public static class QueueManager
    {
        private static readonly string ChatQueuePath = @".\private$\ChatQueue";

        public static void CreateQueues()
        {
            if (!MessageQueue.Exists(ChatQueuePath))
            {
                MessageQueue.Create(ChatQueuePath, true);
            }
        }
    }
}
