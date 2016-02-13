using System;
using System.Data.Entity;

namespace CleverClass.Domain.Business.Entity
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int MaximumScore { get; set; }
        public int Weight { get; set; }

        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Test");

            modelBuilder.Entity<Test>().HasKey(t => t.Id);
            modelBuilder.Entity<Test>().Property(t => t.Id).HasColumnName("Id");
            modelBuilder.Entity<Test>().Property(t => t.Name).HasColumnName("Name");
            modelBuilder.Entity<Test>().Property(t => t.Date).HasColumnName("Date");
            modelBuilder.Entity<Test>().Property(t => t.MaximumScore).HasColumnName("MaximumScore");
            modelBuilder.Entity<Test>().Property(t => t.Weight).HasColumnName("Weight");
        }
    }
}
