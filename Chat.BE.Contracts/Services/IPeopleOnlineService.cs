using Chat.BE.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Contracts
{
    [ContractClass(typeof(PeopleOnlineServiceContract))]
    [ServiceContract]

    public interface IPeopleOnlineService
    {
        [OperationContract]
        void Add(PersonOnlineDTO personOnline);

        [OperationContract]
        void Delete(string ConnectionId);

        [OperationContract]
        IEnumerable<PersonOnlineDTO> Get();
    }

    [ContractClassFor(typeof(IPeopleOnlineService))]
    public class PeopleOnlineServiceContract : IPeopleOnlineService
    {
        public void Add(PersonOnlineDTO personOnline)
        {
            Contract.Requires(personOnline != null);
            Contract.Requires(!string.IsNullOrEmpty(personOnline.Login));
            Contract.Requires(!string.IsNullOrEmpty(personOnline.ConnectionId));
        }

        public void Delete(string ConnectionId)
        {
            Contract.Requires(!string.IsNullOrEmpty(ConnectionId));
        }

        public IEnumerable<PersonOnlineDTO> Get()
        {
            Contract.Ensures(Contract.Result<IEnumerable<PersonOnlineDTO>>() != null);
            return default(IEnumerable<PersonOnlineDTO>);
        }
    }

}
