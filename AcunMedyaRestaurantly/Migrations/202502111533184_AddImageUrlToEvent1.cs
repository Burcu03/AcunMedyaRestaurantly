namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlToEvent1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event1", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event1", "ImageUrl");
        }
    }
}
