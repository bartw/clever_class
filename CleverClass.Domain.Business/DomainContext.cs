using CleverClass.Domain.Business.Entity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverClass.Domain.Business
{
    public class DomainContext : DbContext
    {
        public DbSet<ClassGroup> ClassGroups { get; set; }

        public DomainContext(DbConnection connection, bool connectionIsOwnedByContext)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        [InjectionConstructor()]
        public DomainContext() : base("name=DomainContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ClassGroup.CreateMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
