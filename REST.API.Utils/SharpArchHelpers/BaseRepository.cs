using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SharpArch.Domain.DomainModel;

namespace SharpArch.Domain.PersistenceSupport
{
    /// <summary>
    ///     Defines the public members of a class that implements the repository pattern for entities
    ///     of the specified type.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>

    public abstract class BaseRepository<T> : EnumerableQuery<T>, IRepository<T>
    {
        // Summary:
        //     Initializes a new instance of the System.Linq.EnumerableQuery<T> class and
        //     associates the instance with an expression tree.
        //
        // Parameters:
        //   expression:
        //     An expression tree to associate with the new instance.
        public BaseRepository(Expression expression) : base(expression) { }

        // Summary:
        //     Initializes a new instance of the System.Linq.EnumerableQuery<T> class and
        //     associates it with an System.Collections.Generic.IEnumerable<T> collection.
        //
        // Parameters:
        //   enumerable:
        //     A collection to associate with the new instance.
        public BaseRepository(IEnumerable<T> enumerable) : base(enumerable) { }

        public virtual T this[object id]
        {
            get { return (T)this.Cast<IEntityWithTypedId<object>>().Single(x => x.Id == id); }
        }

        public virtual bool Contains(T item)
        {
            return this.Contains<T>(item);
        }

        public virtual int Count
        {
            get { return this.Count<T>(); }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        //public abstract IDbContext DbContext { get; }

        public virtual void Clear()
        {
            throw new System.NotImplementedException();
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            var source = ((IEnumerable<T>)this).ToArray();
            Array.Copy(source, 0, array, arrayIndex, source.Count());
        }

        public abstract void Add(T item);

        public abstract bool Remove(T item);
        public abstract T Get(int id);
        public abstract IList<T> GetAll();
        public abstract T SaveOrUpdate(T entity);
        public abstract void Delete(T entity);
        public abstract void Delete(int id);


        public void Evict(T entity)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            throw new NotImplementedException();
        }

        public ITransactionManager TransactionManager
        {
            get { throw new NotImplementedException(); }
        }
    }
}

