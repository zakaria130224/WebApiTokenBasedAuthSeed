using BookHome.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHome.Infrastracture
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DatabaseContext")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var conventions = new List<PluralizingTableNameConvention>().ToArray();
            modelBuilder.Conventions.Remove(conventions);
            base.OnModelCreating(modelBuilder);
        }
    }
}
