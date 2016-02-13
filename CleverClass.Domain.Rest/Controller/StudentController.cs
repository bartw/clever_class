using CleverClass.Domain.Business;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Domain.Rest.Controller
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController, IStudentFacade
    {
        private readonly IStudentFacade _studentFacade;

        public StudentController(IStudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<StudentDto> GetAll()
        {
            return _studentFacade.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public StudentDto Get(int id)
        {
            return _studentFacade.Get(id);
        }

        [HttpPost]
        [Route("")]
        public StudentDto Create(StudentDto student)
        {
            return _studentFacade.Create(student);
        }

        [HttpPut]
        [Route("")]
        public StudentDto Update(StudentDto student)
        {
            return _studentFacade.Update(student);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _studentFacade.Delete(id);
        }
    }
}