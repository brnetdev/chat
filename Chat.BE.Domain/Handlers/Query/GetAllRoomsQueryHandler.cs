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

            using (Db db = new Db())
            {
                res.Rooms = db.Rooms.ToList().ToDTOCollection();
            }
                        
            return res;                        
        }
    }
}
