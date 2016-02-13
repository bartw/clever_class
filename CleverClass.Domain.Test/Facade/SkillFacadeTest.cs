using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Facade
{
    public class SkillFacadeTest
    {
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillFacade _skillFacade;

        public SkillFacadeTest()
        {
            _skillRepository = Substitute.For<ISkillRepository>();
            _skillFacade = new SkillFacade(_skillRepository);
        }

        [Fact]
        public void CanGetAll()
        {
            _skillRepository.GetAll().Returns(new List<Skill>
            {
                new Skill { Id = 1, Name = "Bakken" },
                new Skill { Id = 2, Name = "Snijden" }
            });

            var skills = _skillFacade.GetAll();

            _skillRepository.Received().GetAll();
            Assert.NotNull(skills);
            Assert.Equal(2, skills.Count());
        }

        [Fact]
        public void CanGet()
        {
            var skill = new Skill { Id = 1, Name = "Bakken" };

            _skillRepository.Get(skill.Id).Returns(skill);

            var foundSkill = _skillFacade.Get(skill.Id);

            _skillRepository.Received().Get(skill.Id);
            Assert.NotNull(foundSkill);
            Assert.Equal(skill.Id, foundSkill.Id);
            Assert.Equal(skill.Name, foundSkill.Name);
        }

        [Fact]
        public void CanCreate()
        {
            var skillToCreateDto = new SkillDto { Name = "Bakken" };
            var createdSkill = new Skill { Id = 1, Name = skillToCreateDto.Name };

            _skillRepository.Create(Arg.Any<Skill>()).Returns(createdSkill);

            var createdSkillDto = _skillFacade.Create(skillToCreateDto);

            _skillRepository.Received().Create(Arg.Any<Skill>());
            Assert.NotNull(createdSkillDto);
            Assert.Equal(createdSkill.Id, createdSkillDto.Id);
        }

        [Fact]
        public void CanUpdate()
        {
            var updatedSkill = new Skill { Id = 1, Name = "Bakken" };
            var skillToUpdateDto = new SkillDto { Id = updatedSkill.Id, Name = updatedSkill.Name };

            _skillRepository.Update(Arg.Any<Skill>()).Returns(updatedSkill);

            var updatedSkillDto = _skillFacade.Update(skillToUpdateDto);

            _skillRepository.Received().Update(Arg.Any<Skill>());
            Assert.NotNull(updatedSkillDto);
            Assert.Equal(updatedSkillDto.Id, updatedSkillDto.Id);
            Assert.Equal(updatedSkillDto.Name, updatedSkillDto.Name);
        }

        [Fact]
        public void CanDelete()
        {
            var id = 1;

            _skillFacade.Delete(id);

            _skillRepository.Received().Delete(id);
        }
    }
}
