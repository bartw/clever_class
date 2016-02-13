using CleverClass.Domain.Contract.Dto;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Interface
{
    public interface IStudentFacade
    {
        IEnumerable<StudentDto> GetAll();
        StudentDto Get(int id);
        StudentDto Create(StudentDto classGroup);
        StudentDto Update(StudentDto classGroup);
        void Delete(int id);
    }
}
