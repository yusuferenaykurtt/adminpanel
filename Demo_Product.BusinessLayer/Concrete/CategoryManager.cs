using Demo_Product.BusinessLayer.Abstract;
using Demo_Product.DataAccessLayer.Abstracts;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Product.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _ıCategoryDal;

        public CategoryManager(ICategoryDal ıCategoryDal)
        {
            _ıCategoryDal = ıCategoryDal;
        }

        public void TDelete(Category t)
        {

            _ıCategoryDal.delete(t);
                }

        public Category TGetById(int id)
        {
            return _ıCategoryDal.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _ıCategoryDal.getList();
        }

        public void TInsert(Category t)
        {
            _ıCategoryDal.insert(t);
        }

        public void TUpdate(Category t)
        {
            _ıCategoryDal.update(t);
        }
    }
}
