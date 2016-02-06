using CleverClass.Common.Test;
using CleverClass.Domain.Business;
using CleverClass.Domain.Rest;
using Microsoft.Practices.Unity;
using Owin;
using System.Web.Http;
using Unity.WebApi;
using Xunit;

namespace CleverClass.Domain.Test
{
    public class Startup : TestHttpServerStartup
    {
        private IUnityContainer _container;

        public override IUnityContainer UnityContainer
        {
            get
            {
                return _container;
            }
        }

        public override void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            _container = UnityConfig.CreateContainer();
            config.DependencyResolver = new UnityDependencyResolver(_container);
            appBuilder.UseWebApi(config);
        }
    }

    public interface INeedTestHttpServer : IClassFixture<TestHttpServer<Startup>>
    {
    }

    public interface INeedTestDatabase : IClassFixture<TestDatabase<DomainContext>>
    {
    }
}
