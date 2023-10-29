using ANAILYAHOME.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ANAILYAHOME.Repository
{
    //T: هي تعبر عن كل المودل مثل غرف
    public class MainRepository<T> : IRepository<T> where T : class
    {
      
        public MainRepository(AplicetionDbContext context) 
        {
            this.context = context;
        }
        protected AplicetionDbContext context;
        //كلاس (find) ثابت لاي مودل
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }


        public T selectOne(Expression<Func<T, bool>> match)
        {
           return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query =context.Set<T>();

            if (agers.Length > 0)
            {
                foreach(var ager  in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return await query.ToListAsync();
        }

        public void AddOne(T myOda)
        {
            context.Set<T>().Add(myOda);
            context.SaveChanges();
        }

        public void UpdateOne(T myOda)
        {

            context.Set<T>().Update(myOda);
            context.SaveChanges();
        }

        public void DeletOne(T myOda)
        {

            context.Set<T>().Remove(myOda);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {

            context.Set<T>().AddRange(myList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            context.Set<T>().UpdateRange(myList);
            context.SaveChanges();
        }

        public void DeletList(IEnumerable<T> myList)
        {
            context.Set<T>().RemoveRange(myList);
            context.SaveChanges();
        }
    }
}
