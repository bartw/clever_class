using CleverClass.Domain.Contract.Client;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Ui
{
    [RoutePrefix("api/classgroup")]
    public class ClassGroupController : ApiController
    {
        private readonly IClassGroupFacade _classGroupClient;
        
        public ClassGroupController(IClassGroupFacade classGroupClient)
        {
            _classGroupClient = classGroupClient;
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<ClassGroupDto> GetAll()
        {
            return _classGroupClient.GetAll();
        }
        
        [HttpGet]
        [Route("{id}")]
        public ClassGroupDto Get(int id)
        {
            return _classGroupClient.Get(id);
        }
        
        [HttpPost]
        [Route("")]
        public ClassGroupDto Create(ClassGroupDto classGroup)
        {
            return _classGroupClient.Create(classGroup);
        }
        
        [HttpPut]
        [Route("{id}")]
        public ClassGroupDto Update(ClassGroupDto classGroup)
        {
            return _classGroupClient.Update(classGroup);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _classGroupClient.Delete(id);
        }
    }
}