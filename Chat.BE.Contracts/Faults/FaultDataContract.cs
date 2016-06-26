using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Contracts.Faults
{
    [DataContract]
    public class FaultDataContract
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string TechMessage { get; set; }
    }
}
