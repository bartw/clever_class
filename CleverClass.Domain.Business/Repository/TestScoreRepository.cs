using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace CleverClass.Domain.Business.Repository
{
    public interface ITestScoreRepository
    {
        IEnumerable<TestScore> GetAll();
        TestScore Get(int id);
        TestScore Create(TestScore testScore);
        TestScore Update(TestScore testScore);
        void Delete(int id);
    }

    public class TestScoreRepository : ITestScoreRepository
    {
        private readonly DomainContext _dbContext;

        public TestScoreRepository(DomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TestScore> GetAll()
        {
            return _dbContext.TestScores;
        }

        public TestScore Get(int id)
        {
            return _dbContext.TestScores.Find(id);
        }

        public TestScore Create(TestScore testScore)
        {
            var createdTestScore = _dbContext.TestScores.Add(testScore);
            _dbContext.SaveChanges();
            return createdTestScore;
        }

        public TestScore Update(TestScore testScore)
        {
            var updatedTestScore = _dbContext.TestScores.Attach(testScore);
            _dbContext.Entry(testScore).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedTestScore;
        }

        public void Delete(int id)
        {
            var testScoreToDelete = Get(id);
            _dbContext.Entry(testScoreToDelete).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
