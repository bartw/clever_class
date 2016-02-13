using CleverClass.Domain.Contract.Client;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Ui
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly ITestFacade _testClient;

        public TestController(ITestFacade testClient)
        {
            _testClient = testClient;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TestDto> GetAll()
        {
            return _testClient.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public TestDto Get(int id)
        {
            return _testClient.Get(id);
        }

        [HttpPost]
        [Route("")]
        public TestDto Create(TestDto test)
        {
            return _testClient.Create(test);
        }

        [HttpPut]
        [Route("{id}")]
        public TestDto Update(TestDto test)
        {
            return _testClient.Update(test);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _testClient.Delete(id);
        }
    }
}