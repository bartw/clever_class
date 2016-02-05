using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Unity.WebApi;

namespace CleverClass.Domain.Rest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssemblies(BuildManager.GetReferencedAssemblies().Cast<Assembly>()), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Hierarchical, null, true);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}