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
    public class CourseRestClientTest : INeedTestHttpServer
    {
        private readonly TestHttpServer<Startup> _server;
        private readonly ICourseFacade _courseFacade;

        public CourseRestClientTest(TestHttpServer<Startup> server)
        {
            _server = server;
            _courseFacade = Substitute.For<ICourseFacade>();
        }

        [Fact]
        public void CanGetAll()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_courseFacade);

                _courseFacade.GetAll().ReturnsForAnyArgs(new List<CourseDto>
                {
                    new CourseDto { Id = 1, Name = "Bakken" },
                    new CourseDto { Id = 2, Name = "Snijden" }
                });

                var courses = DomainAgent.CreateCourseRestClient(baseUri).GetAll();

                _courseFacade.Received().GetAll();
                Assert.NotNull(courses);
                Assert.Equal(2, courses.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_courseFacade);

                var course = new CourseDto { Id = 1, Name = "Snijden" };

                _courseFacade.Get(course.Id).ReturnsForAnyArgs(course);

                var foundCourse = DomainAgent.CreateCourseRestClient(baseUri).Get(course.Id);

                _courseFacade.Received().Get(course.Id);
                Assert.NotNull(foundCourse);
                Assert.Equal(course.Id, foundCourse.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_courseFacade);

                var courseToCreateDto = new CourseDto { Name = "Bakken" };
                var createdCourseDto = new CourseDto { Id = 1, Name = courseToCreateDto.Name };

                _courseFacade.Create(Arg.Any<CourseDto>()).ReturnsForAnyArgs(createdCourseDto);

                var course = DomainAgent.CreateCourseRestClient(baseUri).Create(courseToCreateDto);

                _courseFacade.Received().Create(Arg.Any<CourseDto>());
                Assert.NotNull(course);
                Assert.True(course.Id > 0);
                Assert.Equal(courseToCreateDto.Name, course.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_courseFacade);

                var courseToUpdateDto = new CourseDto { Id = 1, Name = "Bakken" };

                _courseFacade.Update(Arg.Any<CourseDto>()).ReturnsForAnyArgs(courseToUpdateDto);

                var course = DomainAgent.CreateCourseRestClient(baseUri).Update(courseToUpdateDto);

                _courseFacade.Received().Update(Arg.Any<CourseDto>());
                Assert.NotNull(course);
                Assert.Equal(courseToUpdateDto.Id, course.Id);
                Assert.Equal(courseToUpdateDto.Name, course.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _server.Run((baseUri, server) =>
            {
                server.RegisterInstance(_courseFacade);

                var id = 1;

                DomainAgent.CreateCourseRestClient(baseUri).Delete(id);

                _courseFacade.Received().Delete(id);
            });
        }
    }
}
