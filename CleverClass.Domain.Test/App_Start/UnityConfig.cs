using Microsoft.Practices.Unity;

namespace CleverClass.Domain.Test
{
    public static class UnityConfig
    {
        public static UnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssembliesInBasePath(), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Hierarchical, null, true);
            return container;
        }
    }
}