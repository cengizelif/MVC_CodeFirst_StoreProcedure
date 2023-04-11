namespace MVC_CodeFirst_StoreProcedure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YazarTableAddColumnAciklama3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yazar", "Aciklama3", c => c.String(nullable:false,defaultValue:"test1",defaultValueSql:"test2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yazar", "Aciklama3");
        }
    }
}
