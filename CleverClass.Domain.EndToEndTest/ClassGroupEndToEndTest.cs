using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.EndToEndTest
{
    public class ClassGroupEndToEndTest
    {
        [Fact]
        public void CanCreateAndUpdateAndGetAndDeleteClassGroup()
        {
            var classGroupRestClient = DomainAgent.CreateClassGroupRestClient("http://localhost:50953/");

            var name = "Bakkers";
            var createdClassGroup = classGroupRestClient.Create(new ClassGroupDto
            {
                Name = name
            });

            Assert.NotNull(createdClassGroup);
            Assert.True(createdClassGroup.Id > 0);
            Assert.Equal(name, createdClassGroup.Name);

            var updatedName = "Slagers";
            createdClassGroup.Name = updatedName;
            var updatedClassGroup = classGroupRestClient.Update(createdClassGroup);

            Assert.NotNull(updatedClassGroup);
            Assert.Equal(createdClassGroup.Id, updatedClassGroup.Id);
            Assert.Equal(updatedName, updatedClassGroup.Name);

            var foundClassGroup = classGroupRestClient.Get(updatedClassGroup.Id);

            Assert.NotNull(updatedClassGroup);
            Assert.Equal(updatedClassGroup.Id, foundClassGroup.Id);
            Assert.Equal(updatedName, foundClassGroup.Name);

            var classGroups = classGroupRestClient.GetAll();

            Assert.NotNull(classGroups);
            Assert.True(classGroups.Count() > 0);

            classGroupRestClient.Delete(foundClassGroup.Id);

            var classGroupsAfterDelete = classGroupRestClient.GetAll();

            Assert.NotNull(classGroups);
            Assert.Equal(1, classGroups.Count() - classGroupsAfterDelete.Count());
        }
    }
}
