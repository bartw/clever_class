using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Client
{
    public class ClassGroupRestClient : IClassGroupFacade
    {
        public IEnumerable<ClassGroupDto> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public ClassGroupDto Get(int id)
        {
            throw new NotImplementedException();
        }
        
        public ClassGroupDto Create(ClassGroupDto classGroup)
        {
            throw new NotImplementedException();
        }
        
        public ClassGroupDto Update(ClassGroupDto classGroup)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}