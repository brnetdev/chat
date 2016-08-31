using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Data.Entities
{
    //niewylogowane osoby
    [Table("OnlinePeople")]
    public class OnlinePerson
    {        
        public int Id { get; set; }
        
        public string Login { get; set; }
        public string ConnectionId { get; set; }
        public bool OnLine { get; set; }
    }
}
