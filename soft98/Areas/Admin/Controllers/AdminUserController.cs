using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soft98.Core.Interface;

namespace soft98.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private IAdminRepository _adminRepository;

        public AdminUserController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _adminRepository.ShowUsers();
            
            return View(users);
        }

        public async Task<IActionResult> EditeUser(int id)
        {
            var user = await _adminRepository.ShowUserById(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                ModelState.AddModelError("id","کاربری با این مشخصات وجود ندارد.");
                return View("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditeUser(int id, bool IsActive)
        {
            if (ModelState.IsValid)
            {
               await _adminRepository.UpdateUser(id, IsActive);
               var res = await _adminRepository.SaveChanges();
               if (res)
               {
                   return RedirectToAction("Index");
               }
               else
               {
                   return View(id);
               }
            }
            else
            {
                return View(id);
            }
        }

        public IActionResult DeleteUser(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _adminRepository.ShowUserById(id);
            if (user != null)
            {
                await _adminRepository.RemoveUser(id);
                var res = await _adminRepository.SaveChanges();

                if (res)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
