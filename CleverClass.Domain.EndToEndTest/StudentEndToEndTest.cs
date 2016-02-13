using CleverClass.Domain.Contract;
using CleverClass.Domain.Contract.Dto;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.EndToEndTest
{
    public class StudentEndToEndTest
    {
        [Fact]
        public void CanCreateAndUpdateAndGetAndDeleteStudent()
        {
            var studentRestClient = DomainAgent.CreateStudentRestClient("http://localhost:50953/");

            var name = "Cobretti";
            var createdStudent = studentRestClient.Create(new StudentDto
            {
                LastName = name
            });

            Assert.NotNull(createdStudent);
            Assert.True(createdStudent.Id > 0);
            Assert.Equal(name, createdStudent.LastName);

            var updatedLastName = "Rambo";
            createdStudent.LastName = updatedLastName;
            var updatedStudent = studentRestClient.Update(createdStudent);

            Assert.NotNull(updatedStudent);
            Assert.Equal(createdStudent.Id, updatedStudent.Id);
            Assert.Equal(updatedLastName, updatedStudent.LastName);

            var foundStudent = studentRestClient.Get(updatedStudent.Id);

            Assert.NotNull(updatedStudent);
            Assert.Equal(updatedStudent.Id, foundStudent.Id);
            Assert.Equal(updatedLastName, foundStudent.LastName);

            var students = studentRestClient.GetAll();

            Assert.NotNull(students);
            Assert.True(students.Count() > 0);

            studentRestClient.Delete(foundStudent.Id);

            var studentsAfterDelete = studentRestClient.GetAll();

            Assert.NotNull(students);
            Assert.Equal(1, students.Count() - studentsAfterDelete.Count());
        }
    }
}
