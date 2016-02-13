using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace CleverClass.Domain.Business.Repository
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetAll();
        Skill Get(int id);
        Skill Create(Skill skill);
        Skill Update(Skill skill);
        void Delete(int id);
    }

    public class SkillRepository : ISkillRepository
    {
        private readonly DomainContext _dbContext;

        public SkillRepository(DomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Skill> GetAll()
        {
            return _dbContext.Skills;
        }

        public Skill Get(int id)
        {
            return _dbContext.Skills.Find(id);
        }

        public Skill Create(Skill skill)
        {
            var createdSkill = _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
            return createdSkill;
        }

        public Skill Update(Skill skill)
        {
            var updatedSkill = _dbContext.Skills.Attach(skill);
            _dbContext.Entry(skill).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedSkill;
        }

        public void Delete(int id)
        {
            var skillToDelete = Get(id);
            _dbContext.Entry(skillToDelete).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
