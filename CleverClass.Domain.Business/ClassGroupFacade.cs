using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;

namespace CleverClass.Domain.Business
{
    public class ClassGroupFacade : IClassGroupFacade
    {
        public IEnumerable<ClassGroupDto> GetAll()
        {
            return new List<ClassGroupDto>
            {
                new ClassGroupDto{
                    Id = 1,
                    Name = "Bakkers"
                },
                new ClassGroupDto{
                    Id = 2,
                    Name = "Slagers"
                }
            };
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