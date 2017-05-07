namespace HandmadeItemMarket.Data.Contracts
{
    using System.Linq;

    public interface IDbRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Delete(object id);
    }
}