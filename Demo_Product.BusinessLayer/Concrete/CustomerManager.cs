using Demo_Product.BusinessLayer.Abstract;
using Demo_Product.DataAccessLayer.Abstracts;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Product.EntityLayer.Concrete;
namespace Demo_Product.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _ıCustomerDal;

            public CustomerManager(ICustomerDal customerDal) {
            
            _ıCustomerDal = customerDal;
        }

        public List<Customer> GetCustomerWithJob()
        {
            return _ıCustomerDal.GetCustomerWithJob();
        }

        public void TDelete(Customer t)
        {
            _ıCustomerDal.delete(t);
        }

        public Customer TGetById(int id)
        {
            return _ıCustomerDal.GetById(id);
        }

        public List<Customer> TGetList()
        {
            return _ıCustomerDal.getList();
        }

        public void TInsert(Customer t)
        {
            _ıCustomerDal.insert(t);
        }

        public void TUpdate(Customer t)
        {
            _ıCustomerDal.update(t);
        }
    }
}
