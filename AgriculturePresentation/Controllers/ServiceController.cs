﻿using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
       private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
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


        public IActionResult DeleteService(int id) 
        {
        var values=_serviceService.GetById(id);
            _serviceService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id) 
        {
            var values= _serviceService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }
        public IActionResult deneme()
        {
            return View();
        }

    }
}
