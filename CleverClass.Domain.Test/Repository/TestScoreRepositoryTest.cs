using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Repository
{
    public class TestScoreRepositoryTest : INeedTestDatabase
    {
        private readonly TestDatabase<DomainContext> _testDatabase;

        public TestScoreRepositoryTest(TestDatabase<DomainContext> testDatabase)
        {
            _testDatabase = testDatabase;
        }

        [Fact]
        public void CanGetAll()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var testScore1 = new TestScore
                {
                    Score = 7.5M
                };

                var testScore2 = new TestScore
                {
                    Score = 8.5M
                };

                dbContext.TestScores.Add(testScore1);
                dbContext.TestScores.Add(testScore2);
                dbContext.SaveChanges();

                var testScores = new TestScoreRepository(dbContext).GetAll();

                Assert.NotNull(testScores);
                Assert.Equal(2, testScores.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var testScore1 = new TestScore
                {
                    Score = 7.5M
                };

                var testScore2 = new TestScore
                {
                    Score = 8.5M
                };

                dbContext.TestScores.Add(testScore1);
                dbContext.TestScores.Add(testScore2);
                dbContext.SaveChanges();

                var testScore = new TestScoreRepository(dbContext).Get(testScore2.Id);

                Assert.NotNull(testScore);
                Assert.Equal(testScore2.Id, testScore.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var testScore = new TestScore
                {
                    Score = 7.5M
                };

                var createdTestScore = new TestScoreRepository(dbContext).Create(testScore);

                Assert.NotNull(createdTestScore);
                Assert.True(createdTestScore.Id > 0);
                Assert.Equal(testScore.Score, createdTestScore.Score);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var updatedScore = 9.5M;

                var testScore = new TestScore
                {
                    Score = 7.5M
                };

                dbContext.TestScores.Add(testScore);
                dbContext.SaveChanges();

                testScore.Score = updatedScore;
                var updatedTestScore = new TestScoreRepository(dbContext).Update(testScore);

                Assert.NotNull(updatedTestScore);
                Assert.Equal(testScore.Id, updatedTestScore.Id);
                Assert.Equal(updatedScore, updatedTestScore.Score);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var testScore1 = new TestScore
                {
                    Score = 7.5M
                };

                var testScore2 = new TestScore
                {
                    Score = 8.5M
                };

                dbContext.TestScores.Add(testScore1);
                dbContext.TestScores.Add(testScore2);
                dbContext.SaveChanges();

                new TestScoreRepository(dbContext).Delete(testScore1.Id);

                Assert.Equal(1, dbContext.TestScores.Count());
                Assert.Equal(testScore2.Id, dbContext.TestScores.First().Id);
            });
        }
    }
}