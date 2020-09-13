using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace grfcTest.Infrastructure.Windsor
{
    public class WebMvcInstaller : IWindsorInstaller
    {
        private readonly Assembly[] assemblies;

        public WebMvcInstaller(params Assembly[] assemblies)
        {
            this.assemblies = assemblies;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            foreach (var assembly in assemblies)
            {
                container
                    .Register(Types
                        .FromAssembly(assembly)
                        .BasedOn<IController>()
                        .Configure(c => c.LifestyleTransient())
                    )
                    .Register(Types
                        .FromAssembly(assembly)
                        .Where(
                            type => type.IsClass && (type.Name.EndsWith("Builder") ||
                                                     type.Name.EndsWith("Handler") ||
                                                     type.Name.EndsWith("Validator")))
                        .Configure(c => c.LifestylePerWebRequest())
                        .WithService.FirstInterface()
                    );
            }
        }
    }
}