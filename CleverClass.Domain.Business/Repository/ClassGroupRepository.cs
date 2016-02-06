using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CleverClass.Domain.Business.Repository
{
    public interface IClassGroupRepository
    {
        IEnumerable<ClassGroup> GetAll();
        ClassGroup Get(int id);
        ClassGroup Create(ClassGroup classGroup);
        ClassGroup Update(ClassGroup classGroup);
        void Delete(int id);
    }

    public class ClassGroupRepository : IClassGroupRepository
    {
        private readonly DomainContext _dbContext;

        public ClassGroupRepository(DomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ClassGroup> GetAll()
        {
            return _dbContext.ClassGroups;
        }

        public ClassGroup Get(int id)
        {
            return _dbContext.ClassGroups.Find(id);
        }

        public ClassGroup Create(ClassGroup classGroup)
        {
            var createdClassGroup = _dbContext.ClassGroups.Add(classGroup);
            _dbContext.SaveChanges();
            return createdClassGroup;
        }

        public ClassGroup Update(ClassGroup classGroup)
        {
            var updatedClassGroup = _dbContext.ClassGroups.Attach(classGroup);
            _dbContext.Entry(classGroup).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedClassGroup;
        }

        public void Delete(int id)
        {
            var classGroupToDelete = Get(id);
            _dbContext.Entry(classGroupToDelete).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
