using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Data.Entities
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [MinLength(2)]
        public string Login { get; set; }

        [MaxLength(1024)]        
        public string Content { get; set; }

        public DateTime MessageTime { get; set; }
    }
}
