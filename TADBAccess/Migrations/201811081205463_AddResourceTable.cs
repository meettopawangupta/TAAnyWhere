namespace TADBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResourceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TA_I18NResource",
                c => new
                    {
                        ResourcePkId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Value = c.String(nullable: false, maxLength: 4000),
                        Culture = c.String(nullable: false, maxLength: 10),
                        Type = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ResourcePkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TA_I18NResource");
        }
    }
}
