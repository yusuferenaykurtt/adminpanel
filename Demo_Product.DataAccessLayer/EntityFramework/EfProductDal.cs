using Demo_Product.DataAccessLayer.Abstracts;
using Demo_Product.DataAccessLayer.Concrete;
using Demo_Product.DataAccessLayer.Repositories;
using Demo_Product.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Product.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
      

        public EfProductDal(Context context) : base(context)
        {
        }
    }
}
