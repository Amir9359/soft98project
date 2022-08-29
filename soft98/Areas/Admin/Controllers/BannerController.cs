using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Entities;
using soft98.DataAccessLayer.Migrations;

namespace soft98.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private IAdminRepository _adminRepository;

        public BannerController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _adminRepository.ShowBanner();
            return View(banners);
        }
        public async Task<IActionResult> Details(int id)
        {
            var banner = await _adminRepository.ShowBannerById(id);
            return View(banner);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Banner banner)
        {
            if (ModelState.IsValid)
            {
                await _adminRepository.AddBanner(banner);
                await _adminRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var banner = await _adminRepository.ShowBannerById(id);
            return View(banner);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Banner banner)
        {
            if (ModelState.IsValid)
            {
                var res = await _adminRepository.UpdateBanner(id, banner.PlaceCode, banner.Description, banner.Price, banner.IsActive);
                if (res)
                {
                    await _adminRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(banner);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _adminRepository.RemoveBanner(id);
            if (res)
            {
               await _adminRepository.SaveChanges();
               return RedirectToAction("Index");
            }

            return RedirectToAction("index");
        }

      
    }
}
