using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleverClass.Domain.Test
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
    }
}
