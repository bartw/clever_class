using CleverClass.Domain.Business;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Domain.Rest.Controller
{
    [RoutePrefix("api/skill")]
    public class SkillController : ApiController, ISkillFacade
    {
        private readonly ISkillFacade _skillFacade;

        public SkillController(ISkillFacade skillFacade)
        {
            _skillFacade = skillFacade;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<SkillDto> GetAll()
        {
            return _skillFacade.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public SkillDto Get(int id)
        {
            return _skillFacade.Get(id);
        }

        [HttpPost]
        [Route("")]
        public SkillDto Create(SkillDto skill)
        {
            return _skillFacade.Create(skill);
        }

        [HttpPut]
        [Route("")]
        public SkillDto Update(SkillDto skill)
        {
            return _skillFacade.Update(skill);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _skillFacade.Delete(id);
        }
    }
}