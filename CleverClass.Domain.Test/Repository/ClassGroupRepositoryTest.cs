using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Repository
{
    public class ClassGroupRepositoryTest : INeedTestDatabase
    {
        private readonly TestDatabase<DomainContext> _testDatabase;

        public ClassGroupRepositoryTest(TestDatabase<DomainContext> testDatabase)
        {
            _testDatabase = testDatabase;
        }

        [Fact]
        public void CanGetAll()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var classGroup1 = new ClassGroup
                {
                    Name = "Slagers"
                };

                var classGroup2 = new ClassGroup
                {
                    Name = "Bakkers"
                };

                dbContext.ClassGroups.Add(classGroup1);
                dbContext.ClassGroups.Add(classGroup2);
                dbContext.SaveChanges();

                var classGroups = new ClassGroupRepository(dbContext).GetAll();

                Assert.NotNull(classGroups);
                Assert.Equal(2, classGroups.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var classGroup1 = new ClassGroup
                {
                    Name = "Slagers"
                };

                var classGroup2 = new ClassGroup
                {
                    Name = "Bakkers"
                };

                dbContext.ClassGroups.Add(classGroup1);
                dbContext.ClassGroups.Add(classGroup2);
                dbContext.SaveChanges();

                var classGroup = new ClassGroupRepository(dbContext).Get(classGroup2.Id);

                Assert.NotNull(classGroup);
                Assert.Equal(classGroup2.Id, classGroup.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var classGroup = new ClassGroup
                {
                    Name = "Slagers"
                };

                var createdClassGroup = new ClassGroupRepository(dbContext).Create(classGroup);

                Assert.NotNull(createdClassGroup);
                Assert.True(createdClassGroup.Id > 0);
                Assert.Equal(classGroup.Name, createdClassGroup.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var updatedName = "Koks";

                var classGroup = new ClassGroup
                {
                    Name = "Slagers"
                };

                dbContext.ClassGroups.Add(classGroup);
                dbContext.SaveChanges();

                classGroup.Name = updatedName;
                var updatedClassGroup = new ClassGroupRepository(dbContext).Update(classGroup);

                Assert.NotNull(updatedClassGroup);
                Assert.Equal(classGroup.Id, updatedClassGroup.Id);
                Assert.Equal(updatedName, updatedClassGroup.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var classGroup1 = new ClassGroup
                {
                    Name = "Slagers"
                };

                var classGroup2 = new ClassGroup
                {
                    Name = "Bakkers"
                };

                dbContext.ClassGroups.Add(classGroup1);
                dbContext.ClassGroups.Add(classGroup2);
                dbContext.SaveChanges();

                new ClassGroupRepository(dbContext).Delete(classGroup1.Id);

                Assert.Equal(1, dbContext.ClassGroups.Count());
                Assert.Equal(classGroup2.Id, dbContext.ClassGroups.First().Id);
            });
        }
    }
}
