namespace CrudOperationUsingEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(" Insert into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values(1,0,0,0)");
            Sql("  Insert into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values(2,30,1,10)");
            Sql(" Insert into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values(3,90,3,15)");           
            
            
            //var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MigrationData.sql");
            //Sql(File.ReadAllText(sqlFile));
           
        }
        
        public override void Down()
        {
        }
    }
}
