namespace BookHome.Infrastracture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActive");
        }
    }
}
