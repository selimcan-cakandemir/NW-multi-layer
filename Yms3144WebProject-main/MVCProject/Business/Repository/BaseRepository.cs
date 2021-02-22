using Core;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        ProjectDbContext db = new ProjectDbContext();

        public void Add(T Entity)
        {
            db.Entry(Entity).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

        }

        public void Delete(T Entity)
        {
            db.Entry(Entity).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T Entity)
        {
            db.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
