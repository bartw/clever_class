namespace CleverClass.Domain.Contract.Dto
{
    public class TestScoreDto
    {
        public int Id { get; set; }
        public decimal Score { get; set ; }
        
        public StudentDto Student { get; set; }
        public TestDto Test { get; set; }
    }
}
