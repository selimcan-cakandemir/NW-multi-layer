using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Business.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
