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
    public class ContactController : Controller
    {
        private IAdminRepository _adminRepository;

        public ContactController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _adminRepository.ShowContacts();
            return View(contacts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var contact = await _adminRepository.ShowContactById(id);
            return View(contact);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _adminRepository.RemoveContact(id);
            if (res)
            {
               await _adminRepository.SaveChanges();
               return RedirectToAction("Index");
            }

            return RedirectToAction("index");
        }

    }
}
