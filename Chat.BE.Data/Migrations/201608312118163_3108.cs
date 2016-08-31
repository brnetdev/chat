namespace Chat.BE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3108 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Chat.OnlinePeople",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        ConnectionId = c.String(),
                        OnLine = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Chat.OnlinePeople");
        }
    }
}
