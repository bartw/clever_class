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
    public class StudentRestClientTest : INeedTestHttpServer
    {
        private readonly TestHttpServer<Startup> _server;
        private readonly IStudentFacade _studentFacade;

        public StudentRestClientTest(TestHttpServer<Startup> server)
        {
            _server = server;
            _studentFacade = Substitute.For<IStudentFacade>();
        }

        [Fact]
        public void CanGetAll()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_studentFacade);

                _studentFacade.GetAll().ReturnsForAnyArgs(new List<StudentDto>
                {
                    new StudentDto { Id = 1, LastName = "Rambo" },
                    new StudentDto { Id = 2, LastName = "Cobretti" }
                });

                var students = DomainAgent.CreateStudentRestClient(baseUri).GetAll();

                _studentFacade.Received().GetAll();
                Assert.NotNull(students);
                Assert.Equal(2, students.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_studentFacade);

                var student = new StudentDto { Id = 1, LastName = "Cobretti" };

                _studentFacade.Get(student.Id).ReturnsForAnyArgs(student);

                var foundStudent = DomainAgent.CreateStudentRestClient(baseUri).Get(student.Id);

                _studentFacade.Received().Get(student.Id);
                Assert.NotNull(foundStudent);
                Assert.Equal(student.Id, foundStudent.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_studentFacade);

                var studentToCreateDto = new StudentDto { LastName = "Rambo" };
                var createdStudentDto = new StudentDto { Id = 1, LastName = studentToCreateDto.LastName };

                _studentFacade.Create(Arg.Any<StudentDto>()).ReturnsForAnyArgs(createdStudentDto);

                var student = DomainAgent.CreateStudentRestClient(baseUri).Create(studentToCreateDto);

                _studentFacade.Received().Create(Arg.Any<StudentDto>());
                Assert.NotNull(student);
                Assert.True(student.Id > 0);
                Assert.Equal(studentToCreateDto.LastName, student.LastName);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_studentFacade);

                var studentToUpdateDto = new StudentDto { Id = 1, LastName = "Rambo" };

                _studentFacade.Update(Arg.Any<StudentDto>()).ReturnsForAnyArgs(studentToUpdateDto);

                var student = DomainAgent.CreateStudentRestClient(baseUri).Update(studentToUpdateDto);

                _studentFacade.Received().Update(Arg.Any<StudentDto>());
                Assert.NotNull(student);
                Assert.Equal(studentToUpdateDto.Id, student.Id);
                Assert.Equal(studentToUpdateDto.LastName, student.LastName);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_studentFacade);

                var id = 1;

                DomainAgent.CreateStudentRestClient(baseUri).Delete(id);

                _studentFacade.Received().Delete(id);
            });
        }
    }
}
