using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using Microsoft.Practices.ServiceLocation;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;

namespace LIFE.JOY.Web
{
    public class ServiceLocatorConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DefaultSessionFactoryKeyProvider>().As<ISessionFactoryKeyProvider>();
            builder.RegisterGeneric(typeof(NHRepository<>)).As(typeof(IRepository<>));

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }
    }
}