using Chat.BE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Chat.BE.Contracts.DTO;
using Chat.BE.Data;
using Chat.BE.Data.Entities;

namespace Chat.BE.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Single)]
    public class HistoryService : IHistoryService
    {        
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired =true)]
        public void AddMessage(MessageDTO message)
        {
            using(Db db= new Db())
            {
                db.Messages.Add(new Message { Content = message.Message, Login = message.Login, MessageTime = message.MessageTime });
            }
        }
    }
}
