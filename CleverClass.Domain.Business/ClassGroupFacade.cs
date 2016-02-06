using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CleverClass.Domain.Business
{
    public class ClassGroupFacade : IClassGroupFacade
    {
        private readonly IClassGroupRepository _classGroupRepository;

        public ClassGroupFacade(IClassGroupRepository classGroupRepository)
        {
            _classGroupRepository = classGroupRepository;
        }

        public IEnumerable<ClassGroupDto> GetAll()
        {
            return _classGroupRepository.GetAll().Select(cg => new ClassGroupDto
            {
                Id = cg.Id,
                Name = cg.Name
            });
        }
        
        public ClassGroupDto Get(int id)
        {
            return new ClassGroupDto{
                Id = id,
                Name = "Koks"
            };
        }
        
        public ClassGroupDto Create(ClassGroupDto classGroup)
        {
            return classGroup;
        }
        
        public ClassGroupDto Update(ClassGroupDto classGroup)
        {
            return classGroup;
        }
        
        public void Delete(int id)
        {
            
        }
    }
}