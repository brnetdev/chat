using Chat.BE.Data;
using Chat.BE.Domain.Mappings;
using Chat.BE.Domain.Queries.Room;
using Chat.BE.Infrastructure.CQRS;
using System.Linq;

namespace Chat.BE.Domain.Handlers.Query
{
    public class GetAllRoomsQueryHandler : IQueryHandler<GetAllRoomsQuery, GetAllRoomsQueryResult>
    {
        public GetAllRoomsQueryResult Handle(GetAllRoomsQuery query)
        {            
            var res = new GetAllRoomsQueryResult();
            res.Rooms = new System.Collections.Generic.List<Contracts.DTO.RoomDTO>();
            
            using (Db db = new Db())
            {
                var rooms = db.Rooms.ToList();
                rooms.ForEach(r => res.Rooms.Add(new Contracts.DTO.RoomDTO { Id = r.Id, Descritpion = r.Description, Name = r.Title }));
            }
                        
            return res;                        
        }
    }
}
