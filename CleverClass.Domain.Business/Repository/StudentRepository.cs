using CleverClass.Domain.Business.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace CleverClass.Domain.Business.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Create(Student student);
        Student Update(Student student);
        void Delete(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly DomainContext _dbContext;

        public StudentRepository(DomainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students;
        }

        public Student Get(int id)
        {
            return _dbContext.Students.Find(id);
        }

        public Student Create(Student student)
        {
            var createdStudent = _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return createdStudent;
        }

        public Student Update(Student student)
        {
            var updatedStudent = _dbContext.Students.Attach(student);
            _dbContext.Entry(student).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return updatedStudent;
        }

        public void Delete(int id)
        {
            var studentToDelete = Get(id);
            _dbContext.Entry(studentToDelete).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
