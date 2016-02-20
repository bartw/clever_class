using CleverClass.Common;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Client
{
    public class SkillRestClient : RestClient, ISkillFacade
    {
        public SkillRestClient(Uri baseUri) : base(baseUri)
        {

        }

        public IEnumerable<SkillDto> GetAll()
        {
            return Get<IEnumerable<SkillDto>>("api/skill");
        }

        public SkillDto Get(int id)
        {
            return Get<SkillDto>(string.Format("api/skill/{0}", id));
        }

        public SkillDto Create(SkillDto skill)
        {
            return Post<SkillDto, SkillDto>("api/skill", skill);
        }

        public SkillDto Update(SkillDto skill)
        {
            return Put<SkillDto, SkillDto>("api/skill", skill);
        }

        public void Delete(int id)
        {
            Delete(string.Format("api/skill/{0}", id));
        }
    }
}