using Chat.BE.Data.Entities;
using Chat.BE.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BE.Data
{
    public class Db : DbContext
    {

        public DbSet<Room> Rooms { get; set; }

        public Db() : base("cs")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, Chat.BE.Data.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Chat");
            modelBuilder.Configurations.Add(new RoomEntityConfiguration());
        }



    }
}
