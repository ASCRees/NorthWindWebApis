namespace NorthWindWebApis.DataLayer.migrations.Northwind
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NorthWindWebApis.DataLayer.NORTHWNDEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"migrations\Northwind";
        }

        protected override void Seed(NorthWindWebApis.DataLayer.NORTHWNDEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
