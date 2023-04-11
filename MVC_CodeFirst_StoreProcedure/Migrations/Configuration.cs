namespace MVC_CodeFirst_StoreProcedure.Migrations
{
    using MVC_CodeFirst_StoreProcedure.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_CodeFirst_StoreProcedure.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC_CodeFirst_StoreProcedure.Models.DatabaseContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MVC_CodeFirst_StoreProcedure.Models.DatabaseContext context)
        {

            for (int i = 1; i < 11; i++)
            {
                context.Kitaplar.AddOrUpdate(new Kitap()
                {
                    Id=i,
                    Ad = FakeData.NameData.GetCompanyName(),
                    Aciklama = FakeData.TextData.GetSentences(1),
                    YayinTarihi = FakeData.DateTimeData.GetDatetime()
                });
            }

            context.SaveChanges();

            for (int i = 1; i < 11; i++)
            {
                context.Yazarlar.AddOrUpdate(new Yazar()
                {
                    Id = i,
                    Ad = FakeData.NameData.GetFirstName(),
                    Soyad = FakeData.NameData.GetSurname(),
                    Aciklama="test",
                    Aciklama2=-1,
                    DogumTarihi = FakeData.DateTimeData.GetDatetime()
                });
            }
            context.SaveChanges();
        }
    }
}
