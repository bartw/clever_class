using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.EndToEndTest
{
    public class SkillEndToEndTest
    {
        [Fact]
        public void CanCreateAndUpdateAndGetAndDeleteSkill()
        {
            var skillRestClient = DomainAgent.CreateSkillRestClient("http://localhost:50953/");

            var name = "Bakken";
            var createdSkill = skillRestClient.Create(new SkillDto
            {
                Name = name
            });

            Assert.NotNull(createdSkill);
            Assert.True(createdSkill.Id > 0);
            Assert.Equal(name, createdSkill.Name);

            var updatedName = "Snijden";
            createdSkill.Name = updatedName;
            var updatedSkill = skillRestClient.Update(createdSkill);

            Assert.NotNull(updatedSkill);
            Assert.Equal(createdSkill.Id, updatedSkill.Id);
            Assert.Equal(updatedName, updatedSkill.Name);

            var foundSkill = skillRestClient.Get(updatedSkill.Id);

            Assert.NotNull(updatedSkill);
            Assert.Equal(updatedSkill.Id, foundSkill.Id);
            Assert.Equal(updatedName, foundSkill.Name);

            var skills = skillRestClient.GetAll();

            Assert.NotNull(skills);
            Assert.True(skills.Count() > 0);

            skillRestClient.Delete(foundSkill.Id);

            var skillsAfterDelete = skillRestClient.GetAll();

            Assert.NotNull(skills);
            Assert.Equal(1, skills.Count() - skillsAfterDelete.Count());
        }
    }
}
