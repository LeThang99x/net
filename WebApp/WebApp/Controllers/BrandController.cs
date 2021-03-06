﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BrandController : Controller
    {
        BrandRepository repository;
        public BrandController(IConfiguration configuration)
        {
            repository = new BrandRepository(configuration);
        }
        public IActionResult Index()
        {
            return View(repository.GetBrands());
        }

        public IActionResult Detail(int id)
        {
            return Json(repository.GetBrandById(id));
        }


        [HttpPost]
        public IActionResult Create(Brand obj)
        {
            repository.Save(obj);
            return Redirect("/Brand/index");
        }
    }
}
