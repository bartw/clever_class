using CleverClass.Domain.Business;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Domain.Rest.Controller
{
    [RoutePrefix("api/classgroup")]
    public class ClassGroupController : ApiController, IClassGroupFacade
    {
        private readonly IClassGroupFacade _classGroupFacade;
        
        public ClassGroupController(IClassGroupFacade classGroupFacade)
        {
            _classGroupFacade = classGroupFacade;
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<ClassGroupDto> GetAll()
        {
            return _classGroupFacade.GetAll();
        }
        
        [HttpGet]
        [Route("{id}")]
        public ClassGroupDto Get(int id)
        {
            return _classGroupFacade.Get(id);
        }
        
        [HttpPost]
        [Route("")]
        public ClassGroupDto Create(ClassGroupDto classGroup)
        {
            return _classGroupFacade.Create(classGroup);
        }
        
        [HttpPut]
        [Route("")]
        public ClassGroupDto Update(ClassGroupDto classGroup)
        {
            return _classGroupFacade.Update(classGroup);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _classGroupFacade.Delete(id);
        }
    }
}