namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargotest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 250, unicode: false),
                        TakipKodu = c.String(maxLength: 30, unicode: false),
                        Personel = c.String(maxLength: 30, unicode: false),
                        Alici = c.String(maxLength: 30, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayId);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipId = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(maxLength: 30, unicode: false),
                        Aciklama = c.String(maxLength: 250, unicode: false),
                        TarihZaman = c.String(),
                    })
                .PrimaryKey(t => t.KargoTakipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
