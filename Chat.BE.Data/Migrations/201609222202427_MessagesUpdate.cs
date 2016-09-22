namespace Chat.BE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Chat.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 20),
                        Content = c.String(maxLength: 1024),
                        MessageTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Chat.Messages");
        }
    }
}
