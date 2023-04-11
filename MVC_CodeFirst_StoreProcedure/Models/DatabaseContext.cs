using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVC_CodeFirst_StoreProcedure.Migrations;

namespace MVC_CodeFirst_StoreProcedure.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext,Configuration>());
            //Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        public void Kitapekle()
        {
            Database.ExecuteSqlCommand("EXEC InsertData");
        }

        public List<TariheGoreKitaplarclass> TariheGoreKitaplar(int yil1,int yil2)
        {
          return  Database.SqlQuery<TariheGoreKitaplarclass>("EXEC TariheGoreKitaplar @p0,@p1",yil1, yil2).ToList();
        }

        public List<KitapBilgi> KitapBilgiGetir()
        {
            return Database.SqlQuery<KitapBilgi>("Select * from KitapBilgiGetir").ToList(); 
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>().MapToStoredProcedures(x => {
                x.Insert(i => i.HasName("KitapEkle"));
                x.Update(u => { u.HasName("KitapDuzenle");
                    u.Parameter(p => p.Id, "KitapId"); 
                });
                x.Delete(d => { d.HasName("KitapSil");d.Parameter(p => p.Id, "KitapId"); });                
                }) ;

        }

    }

    public class DbInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Database.ExecuteSqlCommand("Create Proc InsertData as begin insert into Kitap values('Şeker Portakalı','Şeker Portakalı','2022-01-01') insert into Kitap values('Yüzyıllık Yalnızlık','Yüzyıllık Yalnızlık','2021-01-01') end");



            //context.Database.ExecuteSqlCommand("select * from kitap where id=@p0 and id=@p1", 5, 10);

            //context.Database.ExecuteSqlCommand("select * from kitap where id=@id1 and id=@id2", new SqlParameter("@id1 ",5), new SqlParameter("@id2 ", 10));

            context.Database.ExecuteSqlCommand("create proc TariheGoreKitaplar (@p0 int , @p1 int) as begin select YayinTarihi,COUNT(YayinTarihi) Adet from Kitap where year(YayinTarihi) between @p0 and @p1 group by YayinTarihi end");

            context.Database.ExecuteSqlCommand("create view KitapBilgiGetir as select Ad 'KitapAdı',YayinTarihi from Kitap");
        }

    }
}