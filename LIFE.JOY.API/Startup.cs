using LIFE.JOY.Data;
using LIFE.JOY.Domain.Models.Basic;
using LIFE.JOY.Web;
using Microsoft.Owin;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Owin;
using SharpArch.Domain.DomainModel;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Helper;
using SharpArch.NHibernate.Web.Mvc;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace LIFE.JOY.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ISessionStorage storage = new WebSessionStorage(HttpContext.Current.ApplicationInstance);

            var allEntities = Assembly.GetAssembly(typeof(Aluno)).GetExportedTypes()
                .Where(t =>
                    typeof(EntityWithTypedId<string>).IsAssignableFrom(t) &&
                    !typeof(EntityWithTypedId<string>).Equals(t) ||
                    typeof(EntityWithTypedId<int>).IsAssignableFrom(t) &&
                    !typeof(EntityWithTypedId<int>).Equals(t))
                .ToList();

            var localMapping = MappingHelper.GetIdentityMappings(allEntities);
            Configuration config = NHibernateSessionHelper.Init(storage, null, null, null, localMapping);
            BuildSchema(config, "gestao_academica.sql");
        }

        private static void BuildSchema(Configuration config, string fileName)
        {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
            new SchemaExport(config).SetOutputFile(path).SetDelimiter(";")
                .Create(true, true); /* DROP AND CREATE SCHEMA */
        }
    }
}