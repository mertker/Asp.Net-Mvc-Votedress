using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.DataAccessLayer.EntityFramework
{
    public interface IRepository<T> 
    {
         List<T> List();

         List<T> List(Expression<Func<T, bool>> where);
         
         T Insert(T obj);

         void Update(T obj);

         void Delete(T obj);

         T Find(Expression<Func<T, bool>> where);
    }
}
