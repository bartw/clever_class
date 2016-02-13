using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Facade
{
    public class StudentFacadeTest
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentFacade _studentFacade;

        public StudentFacadeTest()
        {
            _studentRepository = Substitute.For<IStudentRepository>();
            _studentFacade = new StudentFacade(_studentRepository);
        }

        [Fact]
        public void CanGetAll()
        {
            _studentRepository.GetAll().Returns(new List<Student>
            {
                new Student { Id = 1, LastName = "Cobretti" },
                new Student { Id = 2, LastName = "Rambo" }
            });

            var students = _studentFacade.GetAll();

            _studentRepository.Received().GetAll();
            Assert.NotNull(students);
            Assert.Equal(2, students.Count());
        }

        [Fact]
        public void CanGet()
        {
            var student = new Student { Id = 1, LastName = "Cobretti" };

            _studentRepository.Get(student.Id).Returns(student);

            var foundStudent = _studentFacade.Get(student.Id);

            _studentRepository.Received().Get(student.Id);
            Assert.NotNull(foundStudent);
            Assert.Equal(student.Id, foundStudent.Id);
            Assert.Equal(student.LastName, foundStudent.LastName);
        }

        [Fact]
        public void CanCreate()
        {
            var studentToCreateDto = new StudentDto { LastName = "Cobretti" };
            var createdStudent = new Student { Id = 1, LastName = studentToCreateDto.LastName };

            _studentRepository.Create(Arg.Any<Student>()).Returns(createdStudent);

            var createdStudentDto = _studentFacade.Create(studentToCreateDto);

            _studentRepository.Received().Create(Arg.Any<Student>());
            Assert.NotNull(createdStudentDto);
            Assert.Equal(createdStudent.Id, createdStudentDto.Id);
        }

        [Fact]
        public void CanUpdate()
        {
            var updatedStudent = new Student { Id = 1, LastName = "Cobretti" };
            var studentToUpdateDto = new StudentDto { Id = updatedStudent.Id, LastName = updatedStudent.LastName };

            _studentRepository.Update(Arg.Any<Student>()).Returns(updatedStudent);

            var updatedStudentDto = _studentFacade.Update(studentToUpdateDto);

            _studentRepository.Received().Update(Arg.Any<Student>());
            Assert.NotNull(updatedStudentDto);
            Assert.Equal(updatedStudentDto.Id, updatedStudentDto.Id);
            Assert.Equal(updatedStudentDto.LastName, updatedStudentDto.LastName);
        }

        [Fact]
        public void CanDelete()
        {
            var id = 1;

            _studentFacade.Delete(id);

            _studentRepository.Received().Delete(id);
        }
    }
}
