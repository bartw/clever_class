using System.Data.Entity;

namespace CleverClass.Domain.Business.Entity
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().ToTable("Skill");

            modelBuilder.Entity<Skill>().HasKey(s => s.Id);
            modelBuilder.Entity<Skill>().Property(s => s.Id).HasColumnName("Id");
            modelBuilder.Entity<Skill>().Property(s => s.Name).HasColumnName("Name");
            modelBuilder.Entity<Skill>().Property(s => s.Weight).HasColumnName("Weight");
        }
    }
}
