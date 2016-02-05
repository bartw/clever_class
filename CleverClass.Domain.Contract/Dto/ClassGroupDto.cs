using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Dto
{
    public class ClassGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public IEnumerable<CourseDto> Courses { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
