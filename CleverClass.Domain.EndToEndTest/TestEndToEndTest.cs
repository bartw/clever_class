using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using System.Linq;
using System;
using Xunit;

namespace CleverClass.Domain.EndToEndTest
{
    public class TestEndToEndTest
    {
        [Fact]
        public void CanCreateAndUpdateAndGetAndDeleteTest()
        {
            var testRestClient = DomainAgent.CreateTestRestClient("http://localhost:50953/");

            var name = "Bakken";
            var createdTest = testRestClient.Create(new TestDto
            {
                Name = name,
                Date = DateTime.Today
            });

            Assert.NotNull(createdTest);
            Assert.True(createdTest.Id > 0);
            Assert.Equal(name, createdTest.Name);

            var updatedName = "Snijden";
            createdTest.Name = updatedName;
            var updatedTest = testRestClient.Update(createdTest);

            Assert.NotNull(updatedTest);
            Assert.Equal(createdTest.Id, updatedTest.Id);
            Assert.Equal(updatedName, updatedTest.Name);

            var foundTest = testRestClient.Get(updatedTest.Id);

            Assert.NotNull(updatedTest);
            Assert.Equal(updatedTest.Id, foundTest.Id);
            Assert.Equal(updatedName, foundTest.Name);

            var tests = testRestClient.GetAll();

            Assert.NotNull(tests);
            Assert.True(tests.Count() > 0);

            testRestClient.Delete(foundTest.Id);

            var testsAfterDelete = testRestClient.GetAll();

            Assert.NotNull(tests);
            Assert.Equal(1, tests.Count() - testsAfterDelete.Count());
        }
    }
}
