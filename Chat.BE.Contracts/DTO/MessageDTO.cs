using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Contracts.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime MessageTime { get; set; }
        public string Login { get; set; }
    }
}
