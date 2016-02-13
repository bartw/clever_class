using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Repository
{
    public class SkillRepositoryTest : INeedTestDatabase
    {
        private readonly TestDatabase<DomainContext> _testDatabase;

        public SkillRepositoryTest(TestDatabase<DomainContext> testDatabase)
        {
            _testDatabase = testDatabase;
        }

        [Fact]
        public void CanGetAll()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var skill1 = new Skill
                {
                    Name = "Snijden"
                };

                var skill2 = new Skill
                {
                    Name = "Bakken"
                };

                dbContext.Skills.Add(skill1);
                dbContext.Skills.Add(skill2);
                dbContext.SaveChanges();

                var skills = new SkillRepository(dbContext).GetAll();

                Assert.NotNull(skills);
                Assert.Equal(2, skills.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var skill1 = new Skill
                {
                    Name = "Snijden"
                };

                var skill2 = new Skill
                {
                    Name = "Bakken"
                };

                dbContext.Skills.Add(skill1);
                dbContext.Skills.Add(skill2);
                dbContext.SaveChanges();

                var skill = new SkillRepository(dbContext).Get(skill2.Id);

                Assert.NotNull(skill);
                Assert.Equal(skill2.Id, skill.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var skill = new Skill
                {
                    Name = "Snijden"
                };

                var createdSkill = new SkillRepository(dbContext).Create(skill);

                Assert.NotNull(createdSkill);
                Assert.True(createdSkill.Id > 0);
                Assert.Equal(skill.Name, createdSkill.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var updatedName = "Koken";

                var skill = new Skill
                {
                    Name = "Snijden"
                };

                dbContext.Skills.Add(skill);
                dbContext.SaveChanges();

                skill.Name = updatedName;
                var updatedSkill = new SkillRepository(dbContext).Update(skill);

                Assert.NotNull(updatedSkill);
                Assert.Equal(skill.Id, updatedSkill.Id);
                Assert.Equal(updatedName, updatedSkill.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var skill1 = new Skill
                {
                    Name = "Snijden"
                };

                var skill2 = new Skill
                {
                    Name = "Bakken"
                };

                dbContext.Skills.Add(skill1);
                dbContext.Skills.Add(skill2);
                dbContext.SaveChanges();

                new SkillRepository(dbContext).Delete(skill1.Id);

                Assert.Equal(1, dbContext.Skills.Count());
                Assert.Equal(skill2.Id, dbContext.Skills.First().Id);
            });
        }
    }
}