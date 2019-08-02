namespace BookHome.Infrastracture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_UserRole_Update_User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserRoleId");
            AddForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropColumn("dbo.Users", "UserRoleId");
            DropTable("dbo.UserRoles");
        }
    }
}
