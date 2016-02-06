using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;

namespace CleverClass.Domain.Business.Repository
{
    public interface IClassGroupRepository
    {
        IEnumerable<ClassGroup> GetAll();
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
    }
}
