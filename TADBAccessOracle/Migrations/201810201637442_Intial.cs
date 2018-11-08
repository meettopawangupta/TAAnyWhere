namespace TADBAccessOracle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ORCL.TA_Employee",
                c => new
                    {
                        EmployeePkId = c.Long(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.EmployeePkId);
            
            CreateTable(
                "ORCL.TA_Header",
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
                .ForeignKey("ORCL.TA_Employee", t => t.EmployeePkId, cascadeDelete: true)
                .ForeignKey("ORCL.TA_Purpose", t => t.TAPurposePkId, cascadeDelete: true)
                .ForeignKey("ORCL.TA_TravelType", t => t.TATravelTypePkId, cascadeDelete: true)
                .Index(t => t.EmployeePkId)
                .Index(t => t.TAPurposePkId)
                .Index(t => t.TATravelTypePkId);
            
            CreateTable(
                "ORCL.TA_Purpose",
                c => new
                    {
                        TravelPurposePkId = c.Long(nullable: false),
                        TravelPurpose = c.String(nullable: false, maxLength: 50),
                        TravelPurposeDescirption = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TravelPurposePkId);
            
            CreateTable(
                "ORCL.TA_TravelType",
                c => new
                    {
                        TravelTypePkId = c.Long(nullable: false),
                        TravelType = c.String(nullable: false, maxLength: 50),
                        TravelTypeDescirption = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TravelTypePkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ORCL.TA_Header", "TATravelTypePkId", "ORCL.TA_TravelType");
            DropForeignKey("ORCL.TA_Header", "TAPurposePkId", "ORCL.TA_Purpose");
            DropForeignKey("ORCL.TA_Header", "EmployeePkId", "ORCL.TA_Employee");
            DropIndex("ORCL.TA_Header", new[] { "TATravelTypePkId" });
            DropIndex("ORCL.TA_Header", new[] { "TAPurposePkId" });
            DropIndex("ORCL.TA_Header", new[] { "EmployeePkId" });
            DropTable("ORCL.TA_TravelType");
            DropTable("ORCL.TA_Purpose");
            DropTable("ORCL.TA_Header");
            DropTable("ORCL.TA_Employee");
        }
    }
}
