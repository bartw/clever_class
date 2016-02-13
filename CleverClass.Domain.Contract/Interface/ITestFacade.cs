using CleverClass.Domain.Contract.Dto;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Interface
{
    public interface ITestFacade
    {
        IEnumerable<TestDto> GetAll();
        TestDto Get(int id);
        TestDto Create(TestDto classGroup);
        TestDto Update(TestDto classGroup);
        void Delete(int id);
    }
}
