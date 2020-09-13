using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace grfcTest.Infrastructure.Windsor
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, $"The controller for path '{context.HttpContext.Request.Path}' could not be found or it does not implement IController.");
            }

            return (IController) container.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            if (controller is IDisposable disposable)
            {
                disposable.Dispose();
            }

            container.Release(controller);
        }
    }
}
