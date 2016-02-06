using CleverClass.Domain.Business.Entity;
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
            var classGroup = _classGroupRepository.Get(id);

            if (classGroup == null)
            {
                return null;
            }

            return new ClassGroupDto
            {
                Id = classGroup.Id,
                Name = classGroup.Name
            };
        }
        
        public ClassGroupDto Create(ClassGroupDto classGroup)
        {
            var createdClassGroup = _classGroupRepository.Create(new ClassGroup
            {
                Id = classGroup.Id,
                Name = classGroup.Name
            });

            if (createdClassGroup == null)
            {
                return null;
            }

            return new ClassGroupDto
            {
                Id = createdClassGroup.Id,
                Name = createdClassGroup.Name
            };
        }
        
        public ClassGroupDto Update(ClassGroupDto classGroup)
        {
            var updatedClassGroup = _classGroupRepository.Update(new ClassGroup
            {
                Id = classGroup.Id,
                Name = classGroup.Name
            });

            if (updatedClassGroup == null)
            {
                return null;
            }

            return new ClassGroupDto
            {
                Id = updatedClassGroup.Id,
                Name = updatedClassGroup.Name
            };
        }
        
        public void Delete(int id)
        {
            _classGroupRepository.Delete(id);
        }
    }
}