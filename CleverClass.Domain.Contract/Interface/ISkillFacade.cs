using CleverClass.Domain.Contract.Dto;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Interface
{
    public interface ISkillFacade
    {
        IEnumerable<SkillDto> GetAll();
        SkillDto Get(int id);
        SkillDto Create(SkillDto classGroup);
        SkillDto Update(SkillDto classGroup);
        void Delete(int id);
    }
}
