namespace MVC_CodeFirst_StoreProcedure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Aciklama = c.String(),
                        YayinTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.KitapEkle",
                p => new
                    {
                        Ad = p.String(maxLength: 50),
                        Aciklama = p.String(),
                        YayinTarihi = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Kitap]([Ad], [Aciklama], [YayinTarihi])
                      VALUES (@Ad, @Aciklama, @YayinTarihi)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Kitap]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Kitap] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.KitapDuzenle",
                p => new
                    {
                        KitapId = p.Int(),
                        Ad = p.String(maxLength: 50),
                        Aciklama = p.String(),
                        YayinTarihi = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Kitap]
                      SET [Ad] = @Ad, [Aciklama] = @Aciklama, [YayinTarihi] = @YayinTarihi
                      WHERE ([Id] = @KitapId)"
            );
            
            CreateStoredProcedure(
                "dbo.KitapSil",
                p => new
                    {
                        KitapId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Kitap]
                      WHERE ([Id] = @KitapId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.KitapSil");
            DropStoredProcedure("dbo.KitapDuzenle");
            DropStoredProcedure("dbo.KitapEkle");
            DropTable("dbo.Kitap");
        }
    }
}
