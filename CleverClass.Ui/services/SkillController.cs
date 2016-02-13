using CleverClass.Domain.Contract.Client;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Ui
{
    [RoutePrefix("api/skill")]
    public class SkillController : ApiController
    {
        private readonly ISkillFacade _skillClient;

        public SkillController(ISkillFacade skillClient)
        {
            _skillClient = skillClient;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<SkillDto> GetAll()
        {
            return _skillClient.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public SkillDto Get(int id)
        {
            return _skillClient.Get(id);
        }

        [HttpPost]
        [Route("")]
        public SkillDto Create(SkillDto skill)
        {
            return _skillClient.Create(skill);
        }

        [HttpPut]
        [Route("{id}")]
        public SkillDto Update(SkillDto skill)
        {
            return _skillClient.Update(skill);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _skillClient.Delete(id);
        }
    }
}