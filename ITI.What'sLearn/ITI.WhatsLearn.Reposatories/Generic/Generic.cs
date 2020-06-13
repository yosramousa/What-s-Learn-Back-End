using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Reposatories
{
    public class Generic<T>  where T : BaseModel
    {
        private DbSet<T> dbSet;
        public EntitiesContext Context;
        
        public Generic(EntitiesContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }

        public T Add(T T)
        {
            return dbSet.Add(T);
        }
        public T Update(T T)
        {
            if (!dbSet.Local.Any(i => i.ID == T.ID))
                dbSet.Attach(T);

            Context.Entry(T).State = EntityState.Modified;
            return T;
        }
        public void Remove(T T)
        {
            if(T!=null)
            {

                T.IsDeleted = true;
                //if (!dbSet.Local.Any(i => i.ID == T.ID))
                //  dbSet.Attach(T);
                Context.Entry(T).State = EntityState.Modified;

            }
            // dbSet.Remove(T);
        }
        public T GetByID(int id)
        {
           
            return dbSet.Where(i=> i.IsDeleted==false).FirstOrDefault(i => i.ID == id);
        }
        public IQueryable<T> GetAll()
        {
           return dbSet.Where(i=> i.IsDeleted==false) ;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(i => i.IsDeleted == false )
                .Where(filter);
        }

        public int Count()
        {
            return dbSet.Where(i => i.IsDeleted == false).Count();
        }

        


    }
}
