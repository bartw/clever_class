using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.EndToEndTest
{
    public class CourseEndToEndTest
    {
        [Fact]
        public void CanCreateAndUpdateAndGetAndDeleteCourse()
        {
            var courseRestClient = DomainAgent.CreateCourseRestClient("http://localhost:50953/");

            var name = "Bakken";
            var createdCourse = courseRestClient.Create(new CourseDto
            {
                Name = name
            });

            Assert.NotNull(createdCourse);
            Assert.True(createdCourse.Id > 0);
            Assert.Equal(name, createdCourse.Name);

            var updatedName = "Snijden";
            createdCourse.Name = updatedName;
            var updatedCourse = courseRestClient.Update(createdCourse);

            Assert.NotNull(updatedCourse);
            Assert.Equal(createdCourse.Id, updatedCourse.Id);
            Assert.Equal(updatedName, updatedCourse.Name);

            var foundCourse = courseRestClient.Get(updatedCourse.Id);

            Assert.NotNull(updatedCourse);
            Assert.Equal(updatedCourse.Id, foundCourse.Id);
            Assert.Equal(updatedName, foundCourse.Name);

            var courses = courseRestClient.GetAll();

            Assert.NotNull(courses);
            Assert.True(courses.Count() > 0);

            courseRestClient.Delete(foundCourse.Id);

            var coursesAfterDelete = courseRestClient.GetAll();

            Assert.NotNull(courses);
            Assert.Equal(1, courses.Count() - coursesAfterDelete.Count());
        }
    }
}
