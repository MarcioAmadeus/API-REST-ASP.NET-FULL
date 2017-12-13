using NHibernate;
using NHibernate.Linq;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate.Helper;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SharpArch.NHibernate
{
    public class NHRepository<T> : BaseRepository<T>
    {
        public NHRepository() : base(new NHibernateSessionFactoryBuilder().BuildSessionFactory().OpenSession().Query<T>()) { }

        protected virtual ISession Session
        {
            get
            {
                return new NHibernateSessionFactoryBuilder().BuildSessionFactory().OpenSession();
            }
        }

        public override T this[object id]
        {
            get
            {
                return Session.Get<T>(id);
            }
        }

        public override int Count
        {
            get
            {
                return Session.Query<T>().Count();
            }
        }

        //public override IDbContext DbContext
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public override bool Contains(T item)
        {
            return Session.Query<T>().Contains<T>(item);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            var source = Session.Query<T>().ToArray();
            Array.Copy(source, 0, array, arrayIndex, source.Count());
        }

        public override void Add(T item)
        {
            try
            {
                this.Session.Save(item);
            }
            catch
            {
                if (this.Session.IsOpen)
                    this.Session.Close();

                throw;
            }

            this.Session.Flush();
        }

        public override bool Remove(T item)
        {
            Session.Delete(item);
            return true;
        }

        public override T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public override IList<T> GetAll()
        {
            return this.ToList();
        }

        public override T SaveOrUpdate(T entity)
        {
            try
            {
                this.Session.Save(entity);
            }
            catch
            {
                if (this.Session.IsOpen)
                    this.Session.Close();

                throw;
            }

            this.Session.Flush();
            return entity;
        }

        public override void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public override void Delete(int id)
        {
            Session.Delete(Session.Get<T>(id));
        }
    }
}