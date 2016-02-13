using CleverClass.Domain.Contract;
using Microsoft.Practices.Unity;
using System.Web.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace CleverClass.Ui
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterInstance(DomainAgent.CreateClassGroupRestClient(WebConfigurationManager.AppSettings["DomainServiceUrl"]));
            container.RegisterInstance(DomainAgent.CreateCourseRestClient(WebConfigurationManager.AppSettings["DomainServiceUrl"]));
            container.RegisterInstance(DomainAgent.CreateSkillRestClient(WebConfigurationManager.AppSettings["DomainServiceUrl"]));
            container.RegisterInstance(DomainAgent.CreateStudentRestClient(WebConfigurationManager.AppSettings["DomainServiceUrl"]));
            container.RegisterInstance(DomainAgent.CreateTestRestClient(WebConfigurationManager.AppSettings["DomainServiceUrl"]));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}