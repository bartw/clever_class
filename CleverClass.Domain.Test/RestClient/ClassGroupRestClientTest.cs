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
    public class ClassGroupRestClientTest : INeedTestHttpServer
    {
        private readonly TestHttpServer<Startup> _server;
        private readonly IClassGroupFacade _classGroupFacade;

        public ClassGroupRestClientTest(TestHttpServer<Startup> server)
        {
            _server = server;
            _classGroupFacade = Substitute.For<IClassGroupFacade>();
        }

        [Fact]
        public void CanGetAll()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_classGroupFacade);

                _classGroupFacade.GetAll().ReturnsForAnyArgs(new List<ClassGroupDto>
                {
                    new ClassGroupDto { Id = 1, Name = "Bakkers" },
                    new ClassGroupDto { Id = 2, Name = "Slagers" }
                });

                var classGroups = DomainAgent.CreateClassGroupRestClient(baseUri).GetAll();

                _classGroupFacade.Received().GetAll();
                Assert.NotNull(classGroups);
                Assert.Equal(2, classGroups.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_classGroupFacade);

                var classGroup = new ClassGroupDto { Id = 1, Name = "Slagers" };

                _classGroupFacade.Get(classGroup.Id).ReturnsForAnyArgs(classGroup);

                var foundClassGroup = DomainAgent.CreateClassGroupRestClient(baseUri).Get(classGroup.Id);

                _classGroupFacade.Received().Get(classGroup.Id);
                Assert.NotNull(foundClassGroup);
                Assert.Equal(classGroup.Id, foundClassGroup.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_classGroupFacade);

                var classGroupToCreateDto = new ClassGroupDto { Name = "Bakkers" };
                var createdClassGroupDto = new ClassGroupDto { Id = 1, Name = classGroupToCreateDto.Name };

                _classGroupFacade.Create(Arg.Any<ClassGroupDto>()).ReturnsForAnyArgs(createdClassGroupDto);

                var classGroup = DomainAgent.CreateClassGroupRestClient(baseUri).Create(classGroupToCreateDto);

                _classGroupFacade.Received().Create(Arg.Any<ClassGroupDto>());
                Assert.NotNull(classGroup);
                Assert.True(classGroup.Id > 0);
                Assert.Equal(classGroupToCreateDto.Name, classGroup.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_classGroupFacade);

                var classGroupToUpdateDto = new ClassGroupDto { Id = 1, Name = "Bakkers" };

                _classGroupFacade.Update(Arg.Any<ClassGroupDto>()).ReturnsForAnyArgs(classGroupToUpdateDto);

                var classGroup = DomainAgent.CreateClassGroupRestClient(baseUri).Update(classGroupToUpdateDto);

                _classGroupFacade.Received().Update(Arg.Any<ClassGroupDto>());
                Assert.NotNull(classGroup);
                Assert.Equal(classGroupToUpdateDto.Id, classGroup.Id);
                Assert.Equal(classGroupToUpdateDto.Name, classGroup.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_classGroupFacade);

                var id = 1;

                DomainAgent.CreateClassGroupRestClient(baseUri).Delete(id);

                _classGroupFacade.Received().Delete(id);
            });
        }
    }
}
