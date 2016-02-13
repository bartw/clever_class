using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Facade
{
    public class TestFacadeTest
    {
        private readonly ITestRepository _testRepository;
        private readonly ITestFacade _testFacade;

        public TestFacadeTest()
        {
            _testRepository = Substitute.For<ITestRepository>();
            _testFacade = new TestFacade(_testRepository);
        }

        [Fact]
        public void CanGetAll()
        {
            _testRepository.GetAll().Returns(new List<Business.Entity.Test>
            {
                new Business.Entity.Test { Id = 1, Name = "Bakken" },
                new Business.Entity.Test { Id = 2, Name = "Snijden" }
            });

            var tests = _testFacade.GetAll();

            _testRepository.Received().GetAll();
            Assert.NotNull(tests);
            Assert.Equal(2, tests.Count());
        }

        [Fact]
        public void CanGet()
        {
            var test = new Business.Entity.Test { Id = 1, Name = "Bakken" };

            _testRepository.Get(test.Id).Returns(test);

            var foundTest = _testFacade.Get(test.Id);

            _testRepository.Received().Get(test.Id);
            Assert.NotNull(foundTest);
            Assert.Equal(test.Id, foundTest.Id);
            Assert.Equal(test.Name, foundTest.Name);
        }

        [Fact]
        public void CanCreate()
        {
            var testToCreateDto = new TestDto { Name = "Bakken" };
            var createdTest = new Business.Entity.Test { Id = 1, Name = testToCreateDto.Name };

            _testRepository.Create(Arg.Any<Business.Entity.Test>()).Returns(createdTest);

            var createdTestDto = _testFacade.Create(testToCreateDto);

            _testRepository.Received().Create(Arg.Any<Business.Entity.Test>());
            Assert.NotNull(createdTestDto);
            Assert.Equal(createdTest.Id, createdTestDto.Id);
        }

        [Fact]
        public void CanUpdate()
        {
            var updatedTest = new Business.Entity.Test { Id = 1, Name = "Bakken" };
            var testToUpdateDto = new TestDto { Id = updatedTest.Id, Name = updatedTest.Name };

            _testRepository.Update(Arg.Any<Business.Entity.Test>()).Returns(updatedTest);

            var updatedTestDto = _testFacade.Update(testToUpdateDto);

            _testRepository.Received().Update(Arg.Any<Business.Entity.Test>());
            Assert.NotNull(updatedTestDto);
            Assert.Equal(updatedTestDto.Id, updatedTestDto.Id);
            Assert.Equal(updatedTestDto.Name, updatedTestDto.Name);
        }

        [Fact]
        public void CanDelete()
        {
            var id = 1;

            _testFacade.Delete(id);

            _testRepository.Received().Delete(id);
        }
    }
}
