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
    public class FactorBannerController : Controller
    {
        private IAdminRepository _adminRepository;

        public FactorBannerController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bannerFactors = await _adminRepository.ShowFactorBanner();
            return View(bannerFactors);
        }
        public async Task<IActionResult> Details(int id)
        {
            var bannerFactor = await _adminRepository.ShowFactorById(id);
            return View(bannerFactor);
        }
  

        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _adminRepository.RemoveFactorBanner(id);
            if (res)
            {
               await _adminRepository.SaveChanges();
               return RedirectToAction("Index");
            }

            return RedirectToAction("index");
        }

      
    }
}
