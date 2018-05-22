using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Votedress.DataAccessLayer.EntityFramework
{
    public  class GenericRepository<T> : IRepository<T> where T:class
    {
        private DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }
        public DatabaseContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public virtual void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
        }

        public virtual T Find(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).FirstOrDefault();
        }

        public virtual T Insert(T obj)
        {
            var result = _context.Set<T>().Add(obj);
            return result;
        }

        public virtual List<T> List()
        {           
            return _context.Set<T>().ToList();
        }

        public virtual List<T> List(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).ToList();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }


    }
}
