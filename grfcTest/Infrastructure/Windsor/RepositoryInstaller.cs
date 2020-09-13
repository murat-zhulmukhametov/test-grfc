using System;
using Castle.Core;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using grfcTest.DataLayer.Infrastructure;

namespace grfcTest.Infrastructure.Windsor
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly Type entityInterface;

        public RepositoryInstaller(Type entityInterface)
        {
            this.entityInterface = entityInterface;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var interfaceType = typeof(IEntityRepository<>).MakeGenericType(entityInterface);
            var implementedType = typeof(EntityRepository<>).MakeGenericType(entityInterface);
            container
                .Register(Component
                    .For(interfaceType)
                    .ImplementedBy(implementedType)
                    .LifestylePerWebRequest())
                .Register(Types
                    .FromAssembly(entityInterface.Assembly)
                    .Where(
                        type =>
                            type.IsClass &&
                            (type.Name.EndsWith("Repository") || type.Name.EndsWith("Factory")))
                    .Configure(c => c.LifestylePerWebRequest())
                    .WithService.FirstInterface()
                );
        }
    }
}