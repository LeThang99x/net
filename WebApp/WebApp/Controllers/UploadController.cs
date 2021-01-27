using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace WebApp.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult IconMultiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AjaxMultiple(IFormFile[] af)
        {

            List<string> list = new List<string>();
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

            foreach (IFormFile f in af)
            {
                using (Stream stream=System.IO.File.Create(Path.Combine(root, f.FileName)))
                {
                    f.CopyTo(stream);
                }
                list.Add(f.FileName);
            }
            return Json(list);
        }
        public IActionResult Icon()
        {
            return View();
        }
        public IActionResult Ajax()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajax(IFormFile f)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", f.FileName);

            using(Stream stream = System.IO.File.Create(path))
            {
                f.CopyTo(stream);
            }
            return Json(new { name = f.FileName });
        }
        public IActionResult Online()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Online(string url)
        {
            Console.WriteLine(url);
            Console.WriteLine(Path.GetFileName(url));
            string fileName = Path.GetFileName(url);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", fileName);
            using(WebClient client=new WebClient())
            {
                client.DownloadFile(url, path);
            }
            return View("Online",fileName);
        }
        public IActionResult Multiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Mutiple(IFormFile[] af)
        {
            if (af != null)
            {
                foreach (IFormFile f in af)
                {
                    Console.WriteLine(f.FileName);
                }
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile f)
        {
            if (f != null)
            {
                Console.WriteLine("thu muc hien hanh");
                string filename = Helper.RandomString(32) + Path.GetExtension(f.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", filename);
                
                Console.WriteLine(path);
                using(Stream stream = System.IO.File.Create(path))
                {
                    f.CopyTo(stream);
                }
                Console.WriteLine(f.Name);
                //  ten tap tin
                Console.WriteLine(f.FileName);
                Console.WriteLine(f.Length);
                Console.WriteLine(f.ContentType);

                return View("index", f.FileName);
            }
            else
            {
                Console.WriteLine("NULL");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Multiple(IFormFile[] af)
        {
            if (af != null)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");
                List<string> list = new List<string>();
                foreach (IFormFile f in af) 
                {
                    Console.WriteLine(f.FileName);
                    
                    string path = Path.Combine(root, f.FileName);
                    using(Stream stream = System.IO.File.Create(path))
                    {
                        f.CopyTo(stream);
                    }
                    list.Add(f.FileName);
                }
                return View(list);
            }
            return View();
        }
    }
}
