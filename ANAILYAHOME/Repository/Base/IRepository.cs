using System.Linq.Expressions;

namespace ANAILYAHOME.Repository.Base
{
    public interface IRepository<T> where T : class
    {
       T FindById(int id);

        T selectOne(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(params string[] agers);


        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(params string[] agers);

        void AddOne(T myOda);
        void UpdateOne(T myOda);
        void DeletOne(T myOda);

        void AddList(IEnumerable<T> myList);
        void UpdateList(IEnumerable<T> myList);
        void DeletList(IEnumerable<T> myList);
    }
}
