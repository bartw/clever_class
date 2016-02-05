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

namespace CleverClass.Domain.Test
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
                    new ClassGroupDto { Id = 1, Name = "Slagers" }
                });

                var classGroups = DomainAgent.CreateClassGroupRestClient(baseUri).GetAll();

                Assert.NotNull(classGroups);
                Assert.Equal(2, classGroups.Count());
            });
        }
    }
}
