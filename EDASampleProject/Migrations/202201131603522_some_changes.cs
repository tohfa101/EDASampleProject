namespace EDASampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some_changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.staff01office_info", "staff01salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.staff01office_info", "staff01salary", c => c.Int(nullable: false));
        }
    }
}
