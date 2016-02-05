using CleverClass.Common;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Client
{
    public class ClassGroupRestClient : RestClient, IClassGroupFacade
    {
        public ClassGroupRestClient(Uri baseUri) : base(baseUri)
        {

        }

        public IEnumerable<ClassGroupDto> GetAll()
        {
            return Get<IEnumerable<ClassGroupDto>>("api/classgroup");
        }
        
        public ClassGroupDto Get(int id)
        {
            return Get<ClassGroupDto>(string.Format("api/classgroup/{0}", id));
        }
        
        public ClassGroupDto Create(ClassGroupDto classGroup)
        {
            return Post<ClassGroupDto, ClassGroupDto>("api/classgroup", classGroup);
        }
        
        public ClassGroupDto Update(ClassGroupDto classGroup)
        {
            return Put<ClassGroupDto , ClassGroupDto>("api/classgroup", classGroup);
        }
        
        public void Delete(int id)
        {
            Delete(string.Format("api/classgroup/{0}", id));
        }
    }
}