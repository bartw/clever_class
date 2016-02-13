using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CleverClass.Domain.Business
{
    public class StudentFacade : IStudentFacade
    {
        private readonly IStudentRepository _studentRepository;

        public StudentFacade(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<StudentDto> GetAll()
        {
            return _studentRepository.GetAll().Select(s => new StudentDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName
            });
        }

        public StudentDto Get(int id)
        {
            var student = _studentRepository.Get(id);

            if (student == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }

        public StudentDto Create(StudentDto student)
        {
            var createdStudent = _studentRepository.Create(new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            });

            if (createdStudent == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = createdStudent.Id,
                FirstName = createdStudent.FirstName,
                LastName = createdStudent.LastName
            };
        }

        public StudentDto Update(StudentDto student)
        {
            var updatedStudent = _studentRepository.Update(new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            });

            if (updatedStudent == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = updatedStudent.Id,
                FirstName = updatedStudent.FirstName,
                LastName = updatedStudent.LastName
            };
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}