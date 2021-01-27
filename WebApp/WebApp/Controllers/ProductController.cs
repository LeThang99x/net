using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        int size = 20;
        ProductRepository reponsitory;
        BrandRepository brandRepository;
        CategoryRepository categoryRepository;
        public ProductController(IConfiguration configuration)
        {
            reponsitory = new ProductRepository(configuration);
            brandRepository = new BrandRepository(configuration);
            categoryRepository = new CategoryRepository(configuration);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            try
            {
                reponsitory.Edit(obj);
                return Redirect("/product");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Redirect("/product/error");
            }
        }
        public IActionResult Edit(int id)
        {
            ViewBag.brands = brandRepository.GetBrands();
            ViewBag.categories = categoryRepository.GetCategories();
            return View(reponsitory.GetProductById(id));
        }
       
        public IActionResult Index(int id = 1)
        {
            int total;
            List<Product> list=reponsitory.GetProducts((id-1)*size,size,out total);
            ViewBag.pages = ((total - 1) / size)+1;
            ViewBag.p = id;
            Console.WriteLine(total);
            return View(list);
        }
        public IActionResult Lazy()
        {
            int total;

            List<Product> list = reponsitory.GetProducts(0, size, out total);
            ViewBag.n = (total - 1) / size + 1;
            return View(list);
        }
        public IActionResult LoadMore()
        {
            int total;
           
            List<Product> list = reponsitory.GetProducts(0, size, out total);
            ViewBag.n = (total - 1) / size + 1;
            return View(list);
        }


        [HttpPost]
        public IActionResult LoadMore(int id)
        {
            
            return Json(reponsitory.GetProducts((id - 1) * size, size));
        }
        public IActionResult Create()
        {
            ViewBag.brands = brandRepository.GetBrands();
            ViewBag.categories = categoryRepository.GetCategories();
            return View();
        }

        public IActionResult SearchLoadMore(string q)
        {
            int total;
            List<Product> list = reponsitory.SearchProducts(q,0, size, out total);
            ViewBag.n = (total - 1) / size + 1;
            return View(list);
        }


        [HttpPost]
        public IActionResult SearchLoadMore(int p, string q)
        {
            int total;
            List<Product> list = reponsitory.SearchProducts(q, (p-1)*size, size, out total);
            ViewBag.n = (total - 1) / size + 1;
            return Json(list);
        }
        public IActionResult Search(string q, int id=1)
        {
            int total;
            List<Product>list= reponsitory.SearchProducts((q), (id - 1) * size, size,out total);
            ViewBag.n = (total - 1) / size + 1;
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            try
            {
                reponsitory.Add(obj);
                return Redirect("/product");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Redirect("/product/error");
            }
        }
    }
}
