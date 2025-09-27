using Demo_Product.DataAccessLayer.Abstracts;
using Demo_Product.DataAccessLayer.Concrete;
using Demo_Product.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Product.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

      
        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> getList()
        {
            return _context.Set<T>().ToList();
        }

        public void insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
