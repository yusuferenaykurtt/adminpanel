using Demo_Product.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Demo_Product.EntityLayer.Concrete;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerManager _customerManager;
        private readonly JobManager _jobManager;

     
        public CustomerController(CustomerManager customerManager, JobManager jobManager)
        {
            _customerManager = customerManager;
            _jobManager = jobManager;
        }

        public IActionResult Index()
        {
            var values = _customerManager.GetCustomerWithJob();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            List<SelectListItem> values = (from x in _jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.JobName,
                                               Value = x.JobId.ToString()
                                           }).ToList();

            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var validationRules = new BusinessLayer.FluentValidation.CustomerValidator();
            var validationResult = validationRules.Validate(customer);

            if (validationResult.IsValid)
            {
                _customerManager.TInsert(customer);
                return View(customer);
            }
            foreach (var item in validationResult.Errors)
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            return View();
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = _customerManager.TGetById(id);
            _customerManager.TDelete(values);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            List<SelectListItem> values = (from x in _jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.JobName,
                                               Value = x.JobId.ToString()
                                           }).ToList();
            ViewBag.v = values;

            var value = _customerManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            _customerManager.TUpdate(customer);
            return RedirectToAction("Index");
        }
    }
}
