namespace EDASampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_staff01_staff02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.staff01office_info",
                c => new
                    {
                        staff01uin = c.Int(nullable: false, identity: true),
                        staff01name = c.Int(nullable: false),
                        staff01position = c.Int(nullable: false),
                        staff01depart = c.Int(nullable: false),
                        staff01salary = c.Int(nullable: false),
                        staff01image_path = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.staff01uin);
            
            CreateTable(
                "dbo.staff02personal_info",
                c => new
                    {
                        staff02uin = c.Int(nullable: false, identity: true),
                        staff02uin01uin = c.Int(nullable: false),
                        staff02num = c.String(),
                        staff02email = c.String(),
                        staff02address = c.String(),
                    })
                .PrimaryKey(t => t.staff02uin)
                .ForeignKey("dbo.staff01office_info", t => t.staff02uin01uin)
                .Index(t => t.staff02uin01uin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.staff02personal_info", "staff02uin01uin", "dbo.staff01office_info");
            DropIndex("dbo.staff02personal_info", new[] { "staff02uin01uin" });
            DropTable("dbo.staff02personal_info");
            DropTable("dbo.staff01office_info");
        }
    }
}
