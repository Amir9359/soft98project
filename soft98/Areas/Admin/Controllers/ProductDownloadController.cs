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
    public class ProductDownloadController : Controller
    {
        private IAdminRepository _adminRepository;

        public ProductDownloadController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var productDownloads = await _adminRepository.ShowProductDownload();
            return View(productDownloads);
        }
        public async Task<IActionResult> Details(int id)
        {
            var productDownload = await _adminRepository.ShowProductDownloadById(id);
            return View(productDownload);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ProductId = new SelectList(await _adminRepository.ShowProduct(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDownloadFile downloadFile)
        {
            if (ModelState.IsValid)
            {
                if (downloadFile.File != null)
                {
                    var filePath = "";
                    downloadFile.FileName = CodeGenrators.ProductCode() + Path.GetExtension(downloadFile.File.FileName);

                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/", downloadFile.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        downloadFile.File.CopyTo(stream);
                    }

                    downloadFile.DownloadCount = 0 ;

                    await _adminRepository.AddProductDownload(downloadFile);
                    await _adminRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("PicFile", "لطفا یک فایل برای عکس انتخاب کنید.");
                }


            }

            ViewBag.ProductId = new SelectList(await _adminRepository.ShowProduct(), "Id", "Name");
            return View(downloadFile);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ProductId = new SelectList(await _adminRepository.ShowProduct(), "Id", "Name");
            var ProductDownload = await _adminRepository.ShowProductDownloadById(id);
            return View(ProductDownload);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductDownloadFile downloadFile)
        {
            if (ModelState.IsValid)
            {
                bool isEdit = false;
                var NewImageAddress = "";

                if (downloadFile.File != null)
                {
                    string imagePath = "";
                    downloadFile.FileName = CodeGenrators.ProductCode() + Path.GetExtension(downloadFile.File.FileName);
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/", downloadFile.FileName);

                    using (var NewStream = new FileStream(imagePath, FileMode.Create))
                    {
                        downloadFile.File.CopyTo(NewStream);
                    }

                    NewImageAddress = downloadFile.FileName;
                }
                else
                {
                    NewImageAddress = downloadFile.FileName;
                }
                var res = await _adminRepository.UpdateProductDownload(id, downloadFile.ProductId , downloadFile.Productlink,
                    downloadFile.FileName, downloadFile.Volume);
                if (res)
                {
                    await _adminRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProductId = new SelectList(await _adminRepository.ShowProduct(), "Id", "Name");
            return View(downloadFile);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _adminRepository.RemoveProductDownload(id);
            if (res)
            {
                await _adminRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("index");
        }


    }
}
