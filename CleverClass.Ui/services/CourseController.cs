using CleverClass.Domain.Contract.Client;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Ui
{
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private readonly ICourseFacade _courseClient;

        public CourseController(ICourseFacade courseClient)
        {
            _courseClient = courseClient;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CourseDto> GetAll()
        {
            return _courseClient.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public CourseDto Get(int id)
        {
            return _courseClient.Get(id);
        }

        [HttpPost]
        [Route("")]
        public CourseDto Create(CourseDto course)
        {
            return _courseClient.Create(course);
        }

        [HttpPut]
        [Route("{id}")]
        public CourseDto Update(CourseDto course)
        {
            return _courseClient.Update(course);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _courseClient.Delete(id);
        }
    }
}