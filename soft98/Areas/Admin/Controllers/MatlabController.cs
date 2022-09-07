using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Entities;

namespace soft98.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatlabController : Controller
    {
        
        private IAdminRepository _adminRepository;
        public MatlabController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<IActionResult> Index()
        {
            var matlabs =await _adminRepository.ShowMatlabs();

            return View(matlabs);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Matlab matlab)
        {
            if (ModelState.IsValid)
            {
                var newMatlab = new Matlab()
                {
                    Title = matlab.Title,
                    Description = matlab.Description,
                    Date = PersianDateTime.Now.ToString("yyyy/MM/dd"),
                    Show = matlab.Show,
                    NumberSeen = 0,
                    IsSoft = matlab.IsSoft,
                    IsMobile = matlab.IsMobile,
                    IsTech = matlab.IsTech
                };

                await _adminRepository.AddMatlab(newMatlab);
                await _adminRepository.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(matlab);
            }
        }

        public async Task<IActionResult> Edite(int id)
        {
            var matlab = await _adminRepository.ShowMatlabbyId(id);
            return View(matlab);
        }

        [HttpPost]
        public async Task<IActionResult> Edite(int id, Matlab matlab)
        {
            if (ModelState.IsValid)
            {
                var res = await _adminRepository.UpdateMatlab(id, matlab.Title, matlab.Description, matlab.Show,
                    matlab.IsSoft, matlab.IsMobile, matlab.IsTech);

                if (res)
                {
                    await _adminRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(id);
        }

        public  IActionResult  Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res=  await _adminRepository.DeleteMatlab(id);
            if (res)
            {
                await _adminRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> Details(int id)
        {
           var matlab = await _adminRepository.ShowMatlabbyId(id);
           return View(matlab);
        }

    }
}
