using Demo_Product.DataAccessLayer.Abstracts;
using Demo_Product.DataAccessLayer.Concrete;
using Demo_Product.DataAccessLayer.Repositories;
using Demo_Product.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
{
    private readonly Context _context;

    public EfCustomerDal(Context context) : base(context)
    {
        _context = context;
    }

    public List<Customer> GetCustomerWithJob()
    {
        return _context.Customers
                       .Include(x => x.Job)
                       .ToList();
    }
}
