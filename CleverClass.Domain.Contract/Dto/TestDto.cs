using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Dto
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int MaximumScore { get; set; }
        public int Weight { get; set; }
        
        public SkillDto Skill { get; set; }
        public IEnumerable<TestScoreDto> TestScores { get; set; }
    }
}
