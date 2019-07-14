namespace Wpf_Navigation_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredRuleAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category1", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contact1", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contact1", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Contact1", "CategoryId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact1", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contact1", "Phone", c => c.String());
            AlterColumn("dbo.Contact1", "Name", c => c.String());
            AlterColumn("dbo.Category1", "Name", c => c.String());
        }
    }
}
