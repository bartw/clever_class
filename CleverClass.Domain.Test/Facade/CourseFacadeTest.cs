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
    public class CourseFacadeTest
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseFacade _courseFacade;

        public CourseFacadeTest()
        {
            _courseRepository = Substitute.For<ICourseRepository>();
            _courseFacade = new CourseFacade(_courseRepository);
        }

        [Fact]
        public void CanGetAll()
        {
            _courseRepository.GetAll().Returns(new List<Course>
            {
                new Course { Id = 1, Name = "Bakken" },
                new Course { Id = 2, Name = "Snijden" }
            });

            var courses = _courseFacade.GetAll();

            _courseRepository.Received().GetAll();
            Assert.NotNull(courses);
            Assert.Equal(2, courses.Count());
        }

        [Fact]
        public void CanGet()
        {
            var course = new Course { Id = 1, Name = "Bakken" };

            _courseRepository.Get(course.Id).Returns(course);

            var foundCourse = _courseFacade.Get(course.Id);

            _courseRepository.Received().Get(course.Id);
            Assert.NotNull(foundCourse);
            Assert.Equal(course.Id, foundCourse.Id);
            Assert.Equal(course.Name, foundCourse.Name);
        }

        [Fact]
        public void CanCreate()
        {
            var courseToCreateDto = new CourseDto { Name = "Bakken" };
            var createdCourse = new Course { Id = 1, Name = courseToCreateDto.Name };

            _courseRepository.Create(Arg.Any<Course>()).Returns(createdCourse);

            var createdCourseDto = _courseFacade.Create(courseToCreateDto);

            _courseRepository.Received().Create(Arg.Any<Course>());
            Assert.NotNull(createdCourseDto);
            Assert.Equal(createdCourse.Id, createdCourseDto.Id);
        }

        [Fact]
        public void CanUpdate()
        {
            var updatedCourse = new Course { Id = 1, Name = "Bakken" };
            var courseToUpdateDto = new CourseDto { Id = updatedCourse.Id, Name = updatedCourse.Name };

            _courseRepository.Update(Arg.Any<Course>()).Returns(updatedCourse);

            var updatedCourseDto = _courseFacade.Update(courseToUpdateDto);

            _courseRepository.Received().Update(Arg.Any<Course>());
            Assert.NotNull(updatedCourseDto);
            Assert.Equal(updatedCourseDto.Id, updatedCourseDto.Id);
            Assert.Equal(updatedCourseDto.Name, updatedCourseDto.Name);
        }

        [Fact]
        public void CanDelete()
        {
            var id = 1;

            _courseFacade.Delete(id);

            _courseRepository.Received().Delete(id);
        }
    }
}
