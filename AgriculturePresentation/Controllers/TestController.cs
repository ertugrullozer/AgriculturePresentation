using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TestController : Controller
    {
       private readonly IServiceService _serviceService;

        public TestController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
           var value = _serviceService.GetListAll();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddService() 
        {
            return View( new ServiceAddViewModel());

        }
        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image=model.Image
                    
                });
                return RedirectToAction("Index");

            }
            return View(model);
           

        }
    }
}
