using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Dto
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        
        public CourseDto Course { get; set; }
        public IEnumerable<TestDto> Tests { get; set; }
    }
}
