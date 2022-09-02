using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using soft98.Core.Infrastructure;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Entities;
using soft98.DataAccessLayer.Migrations;

namespace soft98.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IAdminRepository _adminRepository;

        public ProductController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _adminRepository.ShowProduct();
            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _adminRepository.ShowProductById(id);
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _adminRepository.getCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.PicFile != null)
                {
                    var imagePath = "";
                    product.PicName = CodeGenrators.ProductCode() + Path.GetExtension(product.PicFile.FileName);

                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", product.PicName );

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        product.PicFile.CopyTo(stream);
                    }

                    product.SeenCount = 0;
                    product.UpdateDate = PersianDateTime.Now.ToString("yyyy/MM/dd");

                    await _adminRepository.AddProduct(product);
                    await _adminRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("PicFile", "لطفا یک فایل برای عکس نرم افزار انتخاب کنید.");
                }


            }

            ViewBag.CategoryId = new SelectList(await _adminRepository.getCategories(), "Id", "Name");
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(await _adminRepository.getCategories(), "Id", "Name");
            var product = await _adminRepository.ShowProductById(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                bool isEdit = false;
                var NewImageAddress = "";

                if (product.PicFile != null)
                {
                    string imagePath = "";
                    product.PicName = CodeGenrators.ProductCode() + Path.GetExtension(product.PicFile.FileName);
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", product.PicName);

                    using (var NewStream = new FileStream(imagePath, FileMode.Create))
                    {
                        product.PicFile.CopyTo(NewStream);
                    }

                    NewImageAddress = product.PicName;
                }
                else
                {
                    NewImageAddress = product.PicName;
                }
                var res = await _adminRepository.UpdateProduct(id, product.CategoryId ,product.Name, product.Description,
                    NewImageAddress, product.InstallDescription);
                if (res)
                {
                    await _adminRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(await _adminRepository.getCategories(), "Id", "Name");
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _adminRepository.RemoveProduct(id);
            if (res)
            {
                await _adminRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("index");
        }


    }
}
