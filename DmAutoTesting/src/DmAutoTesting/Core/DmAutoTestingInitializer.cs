using System.Linq;
using System.Reflection;
using Autofac;
using DmAutoTesting.Browsers.Pool;
using DmAutoTesting.Configuration;

namespace DmAutoTesting.Core
{
    public class DmAutoTestingInitializer
    {
        private readonly DmAutoTestingConfiguration configuration;

        public DmAutoTestingInitializer(
            DmAutoTestingConfiguration configuration
            )
        {
            this.configuration = configuration;
        }

        public IBrowserPool Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            var classesToRegister = Assembly.GetEntryAssembly().GetTypes()
                .Where(t => t.GetTypeInfo().IsClass)
                .ToArray();
            containerBuilder
                .RegisterTypes(classesToRegister)
                .InstancePerDependency()
                .AsImplementedInterfaces();
            containerBuilder
                .RegisterType<IBrowserPool>()
                .SingleInstance();

            var container = containerBuilder.Build();

            container.Resolve<IDmConfigurationProvider>().Set(configuration);
            return container.Resolve<IBrowserPool>();
        }
    }
}