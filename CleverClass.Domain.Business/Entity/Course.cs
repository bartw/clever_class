using System.Data.Entity;

namespace CleverClass.Domain.Business.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");

            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(c => c.Id).HasColumnName("Id");
            modelBuilder.Entity<Course>().Property(c => c.Name).HasColumnName("Name");
        }
    }
}
