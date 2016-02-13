using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace CleverClass.Domain.Business.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course Get(int id);
        Course Create(Course course);
        Course Update(Course course);
        void Delete(int id);
    }

    public class CourseRepository : ICourseRepository
    {
        private readonly DomainContext _dbContext;

        public CourseRepository(DomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Course> GetAll()
        {
            return _dbContext.Courses;
        }

        public Course Get(int id)
        {
            return _dbContext.Courses.Find(id);
        }

        public Course Create(Course course)
        {
            var createdCourse = _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return createdCourse;
        }

        public Course Update(Course course)
        {
            var updatedCourse = _dbContext.Courses.Attach(course);
            _dbContext.Entry(course).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedCourse;
        }

        public void Delete(int id)
        {
            var courseToDelete = Get(id);
            _dbContext.Entry(courseToDelete).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
