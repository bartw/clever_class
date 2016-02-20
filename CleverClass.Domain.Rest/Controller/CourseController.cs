using CleverClass.Domain.Business;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Domain.Rest.Controller
{
    [RoutePrefix("api/course")]
    public class CourseController : ApiController, ICourseFacade
    {
        private readonly ICourseFacade _courseFacade;

        public CourseController(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CourseDto> GetAll()
        {
            return _courseFacade.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public CourseDto Get(int id)
        {
            return _courseFacade.Get(id);
        }

        [HttpPost]
        [Route("")]
        public CourseDto Create(CourseDto course)
        {
            return _courseFacade.Create(course);
        }

        [HttpPut]
        [Route("")]
        public CourseDto Update(CourseDto course)
        {
            return _courseFacade.Update(course);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _courseFacade.Delete(id);
        }
    }
}