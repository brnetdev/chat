using Chat.BE.Contracts.DTO;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Queries.Room
{
    public class GetAllRoomsQuery : IQuery
    {
        
        
        public bool Validate()
        {
            return true;
        }
    }

    public class GetAllRoomsQueryResult : IQueryResult
    {
        public List<RoomDTO> Rooms { get; set; }

        public bool Validate()
        {
            return true;
        }
    }

}
