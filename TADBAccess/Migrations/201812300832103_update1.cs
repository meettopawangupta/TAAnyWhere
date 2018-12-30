namespace TADBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TA_Employee", "Email", c => c.String(nullable: false, maxLength: 4000));
            AddColumn("dbo.TA_Employee", "Phone", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TA_Employee", "Phone");
            DropColumn("dbo.TA_Employee", "Email");
        }
    }
}
