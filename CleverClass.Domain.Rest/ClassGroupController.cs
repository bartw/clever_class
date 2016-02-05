using CleverClass.Domain.Contract.Interface;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Business;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Domain.Rest
{
    [RoutePrefix("api/classgroup")]
    public class ClassGroupController : ApiController, IClassGroupFacade
    {
        private readonly IClassGroupFacade _classGroupFacade;
        
        public ClassGroupController()
        {
            _classGroupFacade = new ClassGroupFacade();
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
        [Route("{id}")]
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