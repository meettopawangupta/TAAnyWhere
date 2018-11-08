namespace TADBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TA_Employee",
                c => new
                    {
                        EmployeePkId = c.Long(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.EmployeePkId);
            
            CreateTable(
                "dbo.TA_Header",
                c => new
                    {
                        TAHeaderPkId = c.Long(nullable: false, identity: true),
                        TAName = c.String(nullable: false, maxLength: 50),
                        TATravelTypePkId = c.Long(nullable: false),
                        TAPurposePkId = c.Long(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        EmployeePkId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TAHeaderPkId)
                .ForeignKey("dbo.TA_Employee", t => t.EmployeePkId, cascadeDelete: true)
                .ForeignKey("dbo.TA_Purpose", t => t.TAPurposePkId, cascadeDelete: true)
                .ForeignKey("dbo.TA_TravelType", t => t.TATravelTypePkId, cascadeDelete: true)
                .Index(t => t.TATravelTypePkId)
                .Index(t => t.TAPurposePkId)
                .Index(t => t.EmployeePkId);
            
            CreateTable(
                "dbo.TA_Purpose",
                c => new
                    {
                        TravelPurposePkId = c.Long(nullable: false, identity: true),
                        TravelPurpose = c.String(nullable: false, maxLength: 50),
                        TravelPurposeDescirption = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TravelPurposePkId);
            
            CreateTable(
                "dbo.TA_TravelType",
                c => new
                    {
                        TravelTypePkId = c.Long(nullable: false, identity: true),
                        TravelType = c.String(nullable: false, maxLength: 50),
                        TravelTypeDescirption = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TravelTypePkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TA_Header", "TATravelTypePkId", "dbo.TA_TravelType");
            DropForeignKey("dbo.TA_Header", "TAPurposePkId", "dbo.TA_Purpose");
            DropForeignKey("dbo.TA_Header", "EmployeePkId", "dbo.TA_Employee");
            DropIndex("dbo.TA_Header", new[] { "EmployeePkId" });
            DropIndex("dbo.TA_Header", new[] { "TAPurposePkId" });
            DropIndex("dbo.TA_Header", new[] { "TATravelTypePkId" });
            DropTable("dbo.TA_TravelType");
            DropTable("dbo.TA_Purpose");
            DropTable("dbo.TA_Header");
            DropTable("dbo.TA_Employee");
        }
    }
}
