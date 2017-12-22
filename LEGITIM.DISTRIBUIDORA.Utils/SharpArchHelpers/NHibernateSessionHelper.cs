using global::NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using Utils.SharpArchHelpers;
using System.Collections.Generic;

namespace SharpArch.NHibernate.Helper
{
    public static class NHibernateSessionHelper
    {
        public static Configuration Init(
            ISessionStorage storage,
            string cfgFile,
            IDictionary<string, string> cfgProperties,
            string validatorCfgFile, 
            params HbmMapping[] mapping)
        {
            NHibernateSession.InitStorage(storage);
            var config = new Configuration();

            if (cfgProperties != null)
            {
                config.AddProperties(cfgProperties);
            }

            if (string.IsNullOrEmpty(cfgFile) == false)
            {
                config.Configure(cfgFile);
            }
            else
            {
                config.Configure();
            }

            foreach (var map in mapping)
                config.AddDeserializedMapping(map, null);

            return NHibernateSession.AddConfiguration(NHibernateSession.DefaultFactoryKey, config.BuildSessionFactory(), config, validatorCfgFile);
        }

        public static ISession CurrentFor<TEntity>()
        {
            var factoryKey = typeof(TEntity).GetFactoryKey();
            return NHibernateSession.CurrentFor(factoryKey);
        }

        private static string GetFactoryKey(this System.Type t)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

            foreach (System.Attribute attr in attrs)
            {
                if (attr is NHibernateAttribute)
                {
                    NHibernateAttribute a = (NHibernateAttribute)attr;
                    return a.FactoryKey;
                }
            }

            return "nhibernate.current_session";
        }
    }
}
