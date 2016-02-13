using CleverClass.Domain.Business;
using CleverClass.Domain.Contract.Dto;
using CleverClass.Domain.Contract.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace CleverClass.Domain.Rest.Controller
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController, ITestFacade
    {
        private readonly ITestFacade _testFacade;

        public TestController(ITestFacade testFacade)
        {
            _testFacade = testFacade;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<TestDto> GetAll()
        {
            return _testFacade.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public TestDto Get(int id)
        {
            return _testFacade.Get(id);
        }

        [HttpPost]
        [Route("")]
        public TestDto Create(TestDto test)
        {
            return _testFacade.Create(test);
        }

        [HttpPut]
        [Route("")]
        public TestDto Update(TestDto test)
        {
            return _testFacade.Update(test);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _testFacade.Delete(id);
        }
    }
}