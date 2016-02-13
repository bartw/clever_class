using System.Data.Entity;

namespace CleverClass.Domain.Business.Entity
{
    public class TestScore
    {
        public int Id { get; set; }
        public decimal Score { get; set; }

        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestScore>().ToTable("TestScore");

            modelBuilder.Entity<TestScore>().HasKey(ts => ts.Id);
            modelBuilder.Entity<TestScore>().Property(ts => ts.Id).HasColumnName("Id");
            modelBuilder.Entity<TestScore>().Property(ts => ts.Score).HasColumnName("Score");
        }
    }
}
