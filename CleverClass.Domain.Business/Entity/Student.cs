using System.Data.Entity;

namespace CleverClass.Domain.Business.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().Property(s => s.Id).HasColumnName("Id");
            modelBuilder.Entity<Student>().Property(s => s.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<Student>().Property(s => s.LastName).HasColumnName("LastName");
        }
    }
}
