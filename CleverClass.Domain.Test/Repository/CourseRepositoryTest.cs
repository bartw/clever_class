using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Repository
{
    public class CourseRepositoryTest : INeedTestDatabase
    {
        private readonly TestDatabase<DomainContext> _testDatabase;

        public CourseRepositoryTest(TestDatabase<DomainContext> testDatabase)
        {
            _testDatabase = testDatabase;
        }

        [Fact]
        public void CanGetAll()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var course1 = new Course
                {
                    Name = "Snijden"
                };

                var course2 = new Course
                {
                    Name = "Bakken"
                };

                dbContext.Courses.Add(course1);
                dbContext.Courses.Add(course2);
                dbContext.SaveChanges();

                var courses = new CourseRepository(dbContext).GetAll();

                Assert.NotNull(courses);
                Assert.Equal(2, courses.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var course1 = new Course
                {
                    Name = "Snijden"
                };

                var course2 = new Course
                {
                    Name = "Bakken"
                };

                dbContext.Courses.Add(course1);
                dbContext.Courses.Add(course2);
                dbContext.SaveChanges();

                var course = new CourseRepository(dbContext).Get(course2.Id);

                Assert.NotNull(course);
                Assert.Equal(course2.Id, course.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var course = new Course
                {
                    Name = "Snijden"
                };

                var createdCourse = new CourseRepository(dbContext).Create(course);

                Assert.NotNull(createdCourse);
                Assert.True(createdCourse.Id > 0);
                Assert.Equal(course.Name, createdCourse.Name);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var updatedName = "Koken";

                var course = new Course
                {
                    Name = "Snijden"
                };

                dbContext.Courses.Add(course);
                dbContext.SaveChanges();

                course.Name = updatedName;
                var updatedCourse = new CourseRepository(dbContext).Update(course);

                Assert.NotNull(updatedCourse);
                Assert.Equal(course.Id, updatedCourse.Id);
                Assert.Equal(updatedName, updatedCourse.Name);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var course1 = new Course
                {
                    Name = "Snijden"
                };

                var course2 = new Course
                {
                    Name = "Bakken"
                };

                dbContext.Courses.Add(course1);
                dbContext.Courses.Add(course2);
                dbContext.SaveChanges();

                new CourseRepository(dbContext).Delete(course1.Id);

                Assert.Equal(1, dbContext.Courses.Count());
                Assert.Equal(course2.Id, dbContext.Courses.First().Id);
            });
        }
    }
}
