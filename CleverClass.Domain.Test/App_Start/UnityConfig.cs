using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace CleverClass.Domain.Test
{
    public static class UnityConfig
    {
        public static UnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssemblies(BuildManager.GetReferencedAssemblies().Cast<Assembly>()), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Hierarchical, null, true);
            return container;
        }
    }
}