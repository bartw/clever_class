using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CleverClass.Domain.Business
{
    public class SkillFacade : ISkillFacade
    {
        private readonly ISkillRepository _skillRepository;

        public SkillFacade(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public IEnumerable<SkillDto> GetAll()
        {
            return _skillRepository.GetAll().Select(s => new SkillDto
            {
                Id = s.Id,
                Name = s.Name,
                Weight = s.Weight
            });
        }

        public SkillDto Get(int id)
        {
            var skill = _skillRepository.Get(id);

            if (skill == null)
            {
                return null;
            }

            return new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Weight = skill.Weight
            };
        }

        public SkillDto Create(SkillDto skill)
        {
            var createdSkill = _skillRepository.Create(new Skill
            {
                Id = skill.Id,
                Name = skill.Name,
                Weight = skill.Weight
            });

            if (createdSkill == null)
            {
                return null;
            }

            return new SkillDto
            {
                Id = createdSkill.Id,
                Name = createdSkill.Name,
                Weight = createdSkill.Weight
            };
        }

        public SkillDto Update(SkillDto skill)
        {
            var updatedSkill = _skillRepository.Update(new Skill
            {
                Id = skill.Id,
                Name = skill.Name,
                Weight = skill.Weight
            });

            if (updatedSkill == null)
            {
                return null;
            }

            return new SkillDto
            {
                Id = updatedSkill.Id,
                Name = updatedSkill.Name,
                Weight = updatedSkill.Weight
            };
        }

        public void Delete(int id)
        {
            _skillRepository.Delete(id);
        }
    }
}