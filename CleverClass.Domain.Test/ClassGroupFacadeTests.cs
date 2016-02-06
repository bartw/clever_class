using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Interface;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test
{
    public class ClassGroupFacadeTests
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly IClassGroupFacade _classGroupFacade;

        public ClassGroupFacadeTests()
        {
            _classGroupRepository = Substitute.For<IClassGroupRepository>();
            _classGroupFacade = new ClassGroupFacade(_classGroupRepository);
        }

        [Fact]
        public void GivenAClassGroupFacade_WhenGetAllIsCalled_AListOfClassGroupsIsReturned()
        {
            _classGroupRepository.GetAll().ReturnsForAnyArgs(new List<ClassGroup>
            {
                new ClassGroup { Id = 1, Name = "Bakkers" },
                new ClassGroup { Id = 2, Name = "Slagers" }
            });

            var classGroups = _classGroupFacade.GetAll();

            Assert.NotNull(classGroups);
            Assert.Equal(2, classGroups.Count());
        }
    }
}
