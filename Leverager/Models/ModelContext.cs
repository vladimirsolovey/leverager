using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Globalization;
using System.Web.Mvc;

namespace Leverager.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Children).WithMany(i => i.Parents).Map(t => t.MapLeftKey("ParentId").MapRightKey("ChildId").ToTable("CategoryCategories"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Status { get; set; } // Probably needed only for initial population database, in production enviroment this table will be used only through other relations!
        public DbSet<SuggestProduct> SuggestProduct { get; set; }
        public DbSet<FAQ> FAQSet { get; set; }
        public DbSet<ContactUs> ContactUsSet { get; set; }
    }
}