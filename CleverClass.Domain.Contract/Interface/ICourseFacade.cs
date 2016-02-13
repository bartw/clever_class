using CleverClass.Domain.Contract.Dto;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Interface
{
    public interface ICourseFacade
    {
        IEnumerable<CourseDto> GetAll();
        CourseDto Get(int id);
        CourseDto Create(CourseDto classGroup);
        CourseDto Update(CourseDto classGroup);
        void Delete(int id);
    }
}
