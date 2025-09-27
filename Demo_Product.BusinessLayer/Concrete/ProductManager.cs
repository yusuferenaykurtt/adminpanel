using Demo_Product.BusinessLayer.Abstract;
using Demo_Product.DataAccessLayer.Abstracts;
using Demo_Product.DataAccessLayer.EntityFramework;
using Demo_Product.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Product.BusinessLayer.Concrete
{
    public class ProductManager :IGenericService<Product>

    {
        IProductDal _ıProductDal;
        public ProductManager(IProductDal ıProductDal)
        {
            _ıProductDal = ıProductDal;
        }

        public void TDelete(Product t)
        {
          _ıProductDal.delete(t);
        }

        public List<Product> TGetList()
        {
          return  _ıProductDal.getList();
        }

        public void TInsert(Product t)
        {
          _ıProductDal.insert(t);
        }

        public void TUpdate(Product t)
        {
            _ıProductDal.update(t);
        }

        public Product TGetById(int id) => _ıProductDal.GetById(id);
    }
}
