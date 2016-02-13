using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Business.Entity;
using CleverClass.Domain.Business.Repository;
using System.Linq;
using Xunit;

namespace CleverClass.Domain.Test.Repository
{
    public class StudentRepositoryTest : INeedTestDatabase
    {
        private readonly TestDatabase<DomainContext> _testDatabase;

        public StudentRepositoryTest(TestDatabase<DomainContext> testDatabase)
        {
            _testDatabase = testDatabase;
        }

        [Fact]
        public void CanGetAll()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var student1 = new Student
                {
                    LastName = "Rambo"
                };

                var student2 = new Student
                {
                    LastName = "Cobretti"
                };

                dbContext.Students.Add(student1);
                dbContext.Students.Add(student2);
                dbContext.SaveChanges();

                var students = new StudentRepository(dbContext).GetAll();

                Assert.NotNull(students);
                Assert.Equal(2, students.Count());
            });
        }

        [Fact]
        public void CanGet()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var student1 = new Student
                {
                    LastName = "Rambo"
                };

                var student2 = new Student
                {
                    LastName = "Cobretti"
                };

                dbContext.Students.Add(student1);
                dbContext.Students.Add(student2);
                dbContext.SaveChanges();

                var student = new StudentRepository(dbContext).Get(student2.Id);

                Assert.NotNull(student);
                Assert.Equal(student2.Id, student.Id);
            });
        }

        [Fact]
        public void CanCreate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var student = new Student
                {
                    LastName = "Rambo"
                };

                var createdStudent = new StudentRepository(dbContext).Create(student);

                Assert.NotNull(createdStudent);
                Assert.True(createdStudent.Id > 0);
                Assert.Equal(student.LastName, createdStudent.LastName);
            });
        }

        [Fact]
        public void CanUpdate()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var updatedLastName = "Balboa";

                var student = new Student
                {
                    LastName = "Rambo"
                };

                dbContext.Students.Add(student);
                dbContext.SaveChanges();

                student.LastName = updatedLastName;
                var updatedStudent = new StudentRepository(dbContext).Update(student);

                Assert.NotNull(updatedStudent);
                Assert.Equal(student.Id, updatedStudent.Id);
                Assert.Equal(updatedLastName, updatedStudent.LastName);
            });
        }

        [Fact]
        public void CanDelete()
        {
            _testDatabase.RunAndRollback(dbContext =>
            {
                var student1 = new Student
                {
                    LastName = "Rambo"
                };

                var student2 = new Student
                {
                    LastName = "Cobretti"
                };

                dbContext.Students.Add(student1);
                dbContext.Students.Add(student2);
                dbContext.SaveChanges();

                new StudentRepository(dbContext).Delete(student1.Id);

                Assert.Equal(1, dbContext.Students.Count());
                Assert.Equal(student2.Id, dbContext.Students.First().Id);
            });
        }
    }
}