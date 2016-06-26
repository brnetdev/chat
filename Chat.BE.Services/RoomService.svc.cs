using Chat.BE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Chat.BE.Contracts.DTO;

namespace Chat.BE.Services
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Single)]
    public class RoomService : IRoomService
    {        
        public void Add(RoomDTO room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
