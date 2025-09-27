using Demo_Product.BusinessLayer.Abstract;
using Demo_Product.DataAccessLayer.Abstracts;
using Demo_Product.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Product.BusinessLayer.Concrete
{
    public class JobManager : IGenericService<Job>
    {

        IJobDal _ıJobDal;

        public JobManager(IJobDal ıJobDal)
        {
            _ıJobDal = ıJobDal;
        }

        public void TDelete(Job t)
        {
            _ıJobDal.delete(t);
        }

        public Job TGetById(int id)
        {
         return   _ıJobDal.GetById(id);
        }

        public List<Job> TGetList()
        {
           return _ıJobDal.getList();
        }

        public void TInsert(Job t)
        {
           _ıJobDal.insert(t);
        }

        public void TUpdate(Job t)
        {
            _ıJobDal.update(t);
        }
    }
}
