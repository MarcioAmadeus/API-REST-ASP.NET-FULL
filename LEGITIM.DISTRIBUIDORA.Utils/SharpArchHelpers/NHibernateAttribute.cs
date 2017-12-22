using System;

namespace Utils.SharpArchHelpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class NHibernateAttribute : Attribute
    {
        public string FactoryKey { set; get;  }

        public NHibernateAttribute()
        {
            this.FactoryKey = "nhibernate.current_session";
        }
    }
}
