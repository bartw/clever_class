using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace CleverClass.Domain.Business.Repository
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAll();
        Test Get(int id);
        Test Create(Test test);
        Test Update(Test test);
        void Delete(int id);
    }

    public class TestRepository : ITestRepository
    {
        private readonly DomainContext _dbContext;

        public TestRepository(DomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Test> GetAll()
        {
            return _dbContext.Tests;
        }

        public Test Get(int id)
        {
            return _dbContext.Tests.Find(id);
        }

        public Test Create(Test test)
        {
            var createdTest = _dbContext.Tests.Add(test);
            _dbContext.SaveChanges();
            return createdTest;
        }

        public Test Update(Test test)
        {
            var updatedTest = _dbContext.Tests.Attach(test);
            _dbContext.Entry(test).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedTest;
        }

        public void Delete(int id)
        {
            var testToDelete = Get(id);
            _dbContext.Entry(testToDelete).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
