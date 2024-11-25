using ProvaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProvaMVC.DAL
{
    public class UserContext : DbContext
    {

        public UserContext() : base("UserContext")
        {
        }

        public DbSet<UserViewModel> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}