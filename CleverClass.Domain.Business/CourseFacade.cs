using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CleverClass.Domain.Business
{
    public class CourseFacade : ICourseFacade
    {
        private readonly ICourseRepository _courseRepository;

        public CourseFacade(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            return _courseRepository.GetAll().Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public CourseDto Get(int id)
        {
            var course = _courseRepository.Get(id);

            if (course == null)
            {
                return null;
            }

            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name
            };
        }

        public CourseDto Create(CourseDto course)
        {
            var createdCourse = _courseRepository.Create(new Course
            {
                Id = course.Id,
                Name = course.Name
            });

            if (createdCourse == null)
            {
                return null;
            }

            return new CourseDto
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name
            };
        }

        public CourseDto Update(CourseDto course)
        {
            var updatedCourse = _courseRepository.Update(new Course
            {
                Id = course.Id,
                Name = course.Name
            });

            if (updatedCourse == null)
            {
                return null;
            }

            return new CourseDto
            {
                Id = updatedCourse.Id,
                Name = updatedCourse.Name
            };
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }
    }
}