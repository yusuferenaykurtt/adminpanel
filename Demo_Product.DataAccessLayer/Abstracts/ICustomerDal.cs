using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Product.EntityLayer.Concrete;

namespace Demo_Product.DataAccessLayer.Abstracts
{
    public interface ICustomerDal:IGenericDal<Customer>
    {

        public List<Customer> GetCustomerWithJob();
    }
}
