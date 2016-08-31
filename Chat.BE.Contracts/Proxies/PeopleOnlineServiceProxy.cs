using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Chat.BE.Contracts.DTO;

namespace Chat.BE.Contracts.Proxies
{
    class PeopleOnlineServiceProxy : ClientBase<IPeopleOnlineService>, IPeopleOnlineService
    {
        public PeopleOnlineServiceProxy(): base("cliPeopleOnlineConf")
        {

        }
        public void Add(PersonOnlineDTO personOnline)
        {
            this.Channel.Add(personOnline);
        }

        public void Delete(string ConnectionId)
        {
            this.Channel.Delete(ConnectionId);
        }

        public IEnumerable<PersonOnlineDTO> Get()
        {
            return this.Channel.Get();
        }
    }
}
