using CleverClass.Common.Test;
using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleverClass.Domain.Test.RestClient
{
    public class TestRestClientTest : INeedTestHttpServer
    {
        private readonly TestHttpServer<Startup> _server;
        private readonly ITestFacade _testFacade;

        public TestRestClientTest(TestHttpServer<Startup> server)
        {
            _server = server;
            _testFacade = Substitute.For<ITestFacade>();
        }

        [Fact]
        public void CanGetAll()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_testFacade);

                _testFacade.GetAll().ReturnsForAnyArgs(new List<TestDto>
                {
                    new TestDto { Id = 1, Name = "Bakken" },
                    new TestDto { Id = 2, Name = "Snijden" }
                });

                var tests = DomainAgent.CreateTestRestClient(baseUri).GetAll();

                _testFacade.Received().GetAll();
                Assert.NotNull(tests);
                Assert.Equal(2, tests.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_testFacade);

                var test = new TestDto { Id = 1, Name = "Snijden" };

                _testFacade.Get(test.Id).ReturnsForAnyArgs(test);

                var foundTest = DomainAgent.CreateTestRestClient(baseUri).Get(test.Id);

                _testFacade.Received().Get(test.Id);
                Assert.NotNull(foundTest);
                Assert.Equal(test.Id, foundTest.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_testFacade);

                var testToCreateDto = new TestDto { Name = "Bakken" };
                var createdTestDto = new TestDto { Id = 1, Name = testToCreateDto.Name };

                _testFacade.Create(Arg.Any<TestDto>()).ReturnsForAnyArgs(createdTestDto);

                var test = DomainAgent.CreateTestRestClient(baseUri).Create(testToCreateDto);

                _testFacade.Received().Create(Arg.Any<TestDto>());
                Assert.NotNull(test);
                Assert.True(test.Id > 0);
                Assert.Equal(testToCreateDto.Name, test.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_testFacade);

                var testToUpdateDto = new TestDto { Id = 1, Name = "Bakken" };

                _testFacade.Update(Arg.Any<TestDto>()).ReturnsForAnyArgs(testToUpdateDto);

                var test = DomainAgent.CreateTestRestClient(baseUri).Update(testToUpdateDto);

                _testFacade.Received().Update(Arg.Any<TestDto>());
                Assert.NotNull(test);
                Assert.Equal(testToUpdateDto.Id, test.Id);
                Assert.Equal(testToUpdateDto.Name, test.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_testFacade);

                var id = 1;

                DomainAgent.CreateTestRestClient(baseUri).Delete(id);

                _testFacade.Received().Delete(id);
            });
        }
    }
}
