using Demo_Product.BusinessLayer.Concrete;
using Demo_Product.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        private readonly JobManager _jobManager;

        // DI ile JobManager al
        public JobController(JobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public IActionResult Index()
        {
            var values = _jobManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJob(Job j)
        {
            _jobManager.TInsert(j);
            return View(j); // (PRG için sonra düzenleyeceğiz)
        }

        [HttpGet]
        public IActionResult EditJob(int id)
        {
            _jobManager.TGetById(id); // (model dönüşünü sonra düzenleyeceğiz)
            return View("Index");
        }

        [HttpPost]
        public IActionResult EditJob(Job j)
        {
            _jobManager.TUpdate(j);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteJob(int id)
        {
            var values = _jobManager.TGetById(id);
            _jobManager.TDelete(values);
            return View("Index"); // (RedirectToAction’a sonra geçeriz)
        }
    }
}
