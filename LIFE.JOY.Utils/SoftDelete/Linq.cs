using LIFE.JOY.Utils.Enums;
using SharpArch.Domain.PersistenceSupport;

namespace LIFE.JOY.Utils.SoftDelete
{
    public static class SoftDelete
    {
        public static bool SoftRemove<TSource>(this IRepository<TSource> repository, TSource item)
        {
            if (!(typeof(ISoftDelete).IsAssignableFrom(typeof(TSource))))
            {
                return false;
            }

            var itemAux = item as ISoftDelete;
            itemAux.Ativo = eSimNao.N;

            item = (TSource)itemAux;
            //CHECK
            repository.SaveOrUpdate(item);

            return true;
        }
    }
}
