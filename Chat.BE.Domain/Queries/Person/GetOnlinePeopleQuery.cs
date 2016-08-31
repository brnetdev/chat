using Chat.BE.Infrastructure.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Domain.Queries.Person
{
    public class GetOnlinePeopleQuery : IQuery
    {
        public bool Validate()
        {
            return true;
        }
    }
    
    public class PersonItem
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public string Login { get; set; }
        public bool Online { get; set; }
    }

    public class GetOnlinePeopleQueryResult : IQueryResult
    {
        public List<PersonItem> PeopleOnline { get; set; } = new List<PersonItem>();

        public bool Validate()
        {
            return true;
        }
    }

}
