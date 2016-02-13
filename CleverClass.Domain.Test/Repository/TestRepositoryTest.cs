using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Repository;
using System.Linq;
using System;
using Xunit;

namespace CleverClass.Domain.Test.Repository
{
    public class TestRepositoryTest : INeedTestDatabase
    {
        private readonly TestDatabase<DomainContext> _testDatabase;

        public TestRepositoryTest(TestDatabase<DomainContext> testDatabase)
        {
            _testDatabase = testDatabase;
        }

        [Fact]
        public void CanGetAll()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var test1 = new Business.Entity.Test
                {
                    Name = "Snijden",
                    Date = DateTime.Today
                };

                var test2 = new Business.Entity.Test
                {
                    Name = "Bakken",
                    Date = DateTime.Today
                };

                dbContext.Tests.Add(test1);
                dbContext.Tests.Add(test2);
                dbContext.SaveChanges();

                var tests = new TestRepository(dbContext).GetAll();

                Assert.NotNull(tests);
                Assert.Equal(2, tests.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var test1 = new Business.Entity.Test
                {
                    Name = "Snijden",
                    Date = DateTime.Today
                };

                var test2 = new Business.Entity.Test
                {
                    Name = "Bakken",
                    Date = DateTime.Today
                };

                dbContext.Tests.Add(test1);
                dbContext.Tests.Add(test2);
                dbContext.SaveChanges();

                var test = new TestRepository(dbContext).Get(test2.Id);

                Assert.NotNull(test);
                Assert.Equal(test2.Id, test.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var test = new Business.Entity.Test
                {
                    Name = "Snijden",
                    Date = DateTime.Today
                };

                var createdTest = new TestRepository(dbContext).Create(test);

                Assert.NotNull(createdTest);
                Assert.True(createdTest.Id > 0);
                Assert.Equal(test.Name, createdTest.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var updatedName = "Koken";

                var test = new Business.Entity.Test
                {
                    Name = "Snijden",
                    Date = DateTime.Today
                };

                dbContext.Tests.Add(test);
                dbContext.SaveChanges();

                test.Name = updatedName;
                var updatedTest = new TestRepository(dbContext).Update(test);

                Assert.NotNull(updatedTest);
                Assert.Equal(test.Id, updatedTest.Id);
                Assert.Equal(updatedName, updatedTest.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var test1 = new Business.Entity.Test
                {
                    Name = "Snijden",
                    Date = DateTime.Today
                };

                var test2 = new Business.Entity.Test
                {
                    Name = "Bakken",
                    Date = DateTime.Today
                };

                dbContext.Tests.Add(test1);
                dbContext.Tests.Add(test2);
                dbContext.SaveChanges();

                new TestRepository(dbContext).Delete(test1.Id);

                Assert.Equal(1, dbContext.Tests.Count());
                Assert.Equal(test2.Id, dbContext.Tests.First().Id);
            });
        }
    }
}