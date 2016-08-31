using Chat.BE.Data;
using Chat.BE.Domain.Queries.Person;
using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Handlers.Query
{
    public class GetOnlinePeopleQueryHandler : IQueryHandler<GetOnlinePeopleQuery, GetOnlinePeopleQueryResult>
    {
        public GetOnlinePeopleQueryResult Handle(GetOnlinePeopleQuery query)
        {
            var result = new List<PersonItem>();

            using (Db db = new Db())
            {
                var entities = db.OnlinePeople.Where(p => p.OnLine == true).ToList();
                entities.ForEach(e => 
                {
                    result.Add(new PersonItem
                    {
                        Id = e.Id,
                        Login = e.Login,
                        ConnectionId = e.ConnectionId,
                        Online = e.OnLine                            
                    });
                });
            }

            return new GetOnlinePeopleQueryResult { PeopleOnline = result };
        }
    }
}
