using CleverClass.Domain.Contract.Client;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Ui
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private readonly IStudentFacade _studentClient;

        public StudentController(IStudentFacade studentClient)
        {
            _studentClient = studentClient;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<StudentDto> GetAll()
        {
            return _studentClient.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public StudentDto Get(int id)
        {
            return _studentClient.Get(id);
        }

        [HttpPost]
        [Route("")]
        public StudentDto Create(StudentDto student)
        {
            return _studentClient.Create(student);
        }

        [HttpPut]
        [Route("{id}")]
        public StudentDto Update(StudentDto student)
        {
            return _studentClient.Update(student);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _studentClient.Delete(id);
        }
    }
}