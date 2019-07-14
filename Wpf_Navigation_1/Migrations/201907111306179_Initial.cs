namespace Wpf_Navigation_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Category1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category1", t => t.Category1_Id)
                .Index(t => t.Category1_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact1", "Category1_Id", "dbo.Category1");
            DropIndex("dbo.Contact1", new[] { "Category1_Id" });
            DropTable("dbo.Contact1");
            DropTable("dbo.Category1");
        }
    }
}
