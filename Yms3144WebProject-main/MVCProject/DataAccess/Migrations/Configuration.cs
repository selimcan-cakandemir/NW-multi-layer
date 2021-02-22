namespace DataAccess.Migrations
{
    using DataAccess.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Context.ProjectDbContext context)
        {
                if (!context.Categories.Any())
                {
                    List<Category> categories = new List<Category>()
                    {
                        new Category{ CategoryName="Elektronik",MasterId=1,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,Status=Core.Enums.Status.Active},
                    };

                    //add range adds without having to do a foreach
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }
        }
    }
}
