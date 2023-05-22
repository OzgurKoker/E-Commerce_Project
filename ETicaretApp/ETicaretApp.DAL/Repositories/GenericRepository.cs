using ETicaretApp.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        ETicaretAppContext context = new ETicaretAppContext();

        public void Create(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> ListAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
        
    }
}
