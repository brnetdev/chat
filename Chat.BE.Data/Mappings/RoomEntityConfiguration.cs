using Chat.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Data.Mappings
{
    public class RoomEntityConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Room>
    {
        public RoomEntityConfiguration()
        {
            this.ToTable("Rooms");
        }
    }
}
