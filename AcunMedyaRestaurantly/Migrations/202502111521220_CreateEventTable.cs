namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event1",
                c => new
                    {
                        Event1Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Event1Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Event1");
        }
    }
}
