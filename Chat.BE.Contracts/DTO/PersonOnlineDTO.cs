using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Contracts.DTO
{
    [DataContract(Name="PersonOnline")]
    public class PersonOnlineDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string ConnectionId { get; set; }

        [DataMember]
        public bool IsOnline { get; set; }
    }
}
