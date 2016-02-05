using CleverClass.Domain.Business;
using CleverClass.Domain.Contract.Interface;
using Xunit;

namespace CleverClass.Domain.Test
{
    public class ClassGroupFacadeTests
    {
        private readonly IClassGroupFacade _classGroupFacade;

        public ClassGroupFacadeTests()
        {
            _classGroupFacade = new ClassGroupFacade();
        }

        [Fact]
        public void GivenAClassGroupFacade_WhenGetAllIsCalled_AListOfClassGroupsIsReturned()
        {
            var classGroups = _classGroupFacade.GetAll();

            Assert.NotNull(classGroups);
        }
    }
}
