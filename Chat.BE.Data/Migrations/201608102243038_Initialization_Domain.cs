namespace Chat.BE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization_Domain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Chat.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Chat.Rooms");
        }
    }
}
