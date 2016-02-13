using CleverClass.Domain.Business.Entity;
using Microsoft.Practices.Unity;
using System.Data.Common;
using System.Data.Entity;

namespace CleverClass.Domain.Business
{
    public class DomainContext : DbContext
    {
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestScore> TestScores { get; set; }

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
            Course.CreateMapping(modelBuilder);
            Skill.CreateMapping(modelBuilder);
            Student.CreateMapping(modelBuilder);
            Test.CreateMapping(modelBuilder);
            TestScore.CreateMapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
