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
    public class ClassGroupFacadeTest
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly IClassGroupFacade _classGroupFacade;

        public ClassGroupFacadeTest()
        {
            _classGroupRepository = Substitute.For<IClassGroupRepository>();
            _classGroupFacade = new ClassGroupFacade(_classGroupRepository);
        }

        [Fact]
        public void CanGetAll()
        {
            _classGroupRepository.GetAll().Returns(new List<ClassGroup>
            {
                new ClassGroup { Id = 1, Name = "Bakkers" },
                new ClassGroup { Id = 2, Name = "Slagers" }
            });

            var classGroups = _classGroupFacade.GetAll();

            _classGroupRepository.Received().GetAll();
            Assert.NotNull(classGroups);
            Assert.Equal(2, classGroups.Count());
        }

        [Fact]
        public void CanGet()
        {
            var classGroup = new ClassGroup { Id = 1, Name = "Bakkers" };

            _classGroupRepository.Get(classGroup.Id).Returns(classGroup);

            var foundClassGroup = _classGroupFacade.Get(classGroup.Id);

            _classGroupRepository.Received().Get(classGroup.Id);
            Assert.NotNull(foundClassGroup);
            Assert.Equal(classGroup.Id, foundClassGroup.Id);
            Assert.Equal(classGroup.Name, foundClassGroup.Name);
        }

        [Fact]
        public void CanCreate()
        {
            var classGroupToCreateDto = new ClassGroupDto { Name = "Bakkers" };
            var createdClassGroup = new ClassGroup { Id = 1, Name = classGroupToCreateDto.Name };

            _classGroupRepository.Create(Arg.Any<ClassGroup>()).Returns(createdClassGroup);

            var createdClassGroupDto = _classGroupFacade.Create(classGroupToCreateDto);

            _classGroupRepository.Received().Create(Arg.Any<ClassGroup>());
            Assert.NotNull(createdClassGroupDto);
            Assert.Equal(createdClassGroup.Id, createdClassGroupDto.Id);
        }

        [Fact]
        public void CanUpdate()
        {
            var updatedClassGroup = new ClassGroup { Id = 1, Name = "Bakkers" };
            var classGroupToUpdateDto = new ClassGroupDto { Id = updatedClassGroup.Id, Name = updatedClassGroup.Name };

            _classGroupRepository.Update(Arg.Any<ClassGroup>()).Returns(updatedClassGroup);

            var updatedClassGroupDto = _classGroupFacade.Update(classGroupToUpdateDto);

            _classGroupRepository.Received().Update(Arg.Any<ClassGroup>());
            Assert.NotNull(updatedClassGroupDto);
            Assert.Equal(updatedClassGroupDto.Id, updatedClassGroupDto.Id);
            Assert.Equal(updatedClassGroupDto.Name, updatedClassGroupDto.Name);
        }

        [Fact]
        public void CanDelete()
        {
            var id = 1;

            _classGroupFacade.Delete(id);

            _classGroupRepository.Received().Delete(id);
        }
    }
}
