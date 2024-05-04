﻿using BusinessLayer.Abstract;
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
            return View();

        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {

            _serviceService.Insert(service);
            return RedirectToAction("Index");

        }
    }
}
