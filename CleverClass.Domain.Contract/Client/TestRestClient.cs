using CleverClass.Common;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System;
using System.Collections.Generic;

namespace CleverClass.Domain.Contract.Client
{
    public class TestRestClient : RestClient, ITestFacade
    {
        public TestRestClient(Uri baseUri) : base(baseUri)
        {

        }

        public IEnumerable<TestDto> GetAll()
        {
            return Get<IEnumerable<TestDto>>("api/test");
        }

        public TestDto Get(int id)
        {
            return Get<TestDto>(string.Format("api/test/{0}", id));
        }

        public TestDto Create(TestDto test)
        {
            return Post<TestDto, TestDto>("api/test", test);
        }

        public TestDto Update(TestDto test)
        {
            return Put<TestDto, TestDto>("api/test", test);
        }

        public void Delete(int id)
        {
            Delete(string.Format("api/test/{0}", id));
        }
    }
}