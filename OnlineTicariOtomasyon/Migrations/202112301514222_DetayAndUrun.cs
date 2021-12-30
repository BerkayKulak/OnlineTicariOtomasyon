namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetayAndUrun : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detays", "UrunId", c => c.Int(nullable: false));
            CreateIndex("dbo.Detays", "UrunId");
            AddForeignKey("dbo.Detays", "UrunId", "dbo.Uruns", "UrunId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detays", "UrunId", "dbo.Uruns");
            DropIndex("dbo.Detays", new[] { "UrunId" });
            DropColumn("dbo.Detays", "UrunId");
        }
    }
}
