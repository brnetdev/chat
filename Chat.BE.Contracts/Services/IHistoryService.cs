using Chat.BE.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Contracts
{
    [ServiceContract]
    public interface IHistoryService
    {
        [OperationContract(IsOneWay = true)]
        void AddMessage(MessageDTO message);
    }
}
