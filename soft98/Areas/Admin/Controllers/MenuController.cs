using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using soft98.Core.Interface;
using soft98.DataAccessLayer.Entities;

namespace soft98.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private IAdminRepository _adminRepository;

        public MenuController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _adminRepository.getCategories();

            return View(category);
        }

        public async Task<IActionResult> Craete()
        {
            var category = await _adminRepository.getCategories();
            ViewBag.cat = new SelectList(category, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Craete(Category category)
        {
            if (ModelState.IsValid)
            {
                var cat = new Category()
                {
                    Name = category.Name,
                    ParentId = category.ParentId
                };
                var catid = await _adminRepository.AddCategory(cat);
                await _adminRepository.SaveChanges();

                return RedirectToAction("Index", "Menu");
            }
            else
            {
                var categories = await _adminRepository.getCategories();
                ViewBag.cat = new SelectList(categories, "Id", "Name");
                return View(category);
            }
        }

        public async Task<IActionResult> Edite(int id)
        {
            var cat =await _adminRepository.GetCategory(id);
            var categories = await _adminRepository.getCategories();
            ViewBag.cat = new SelectList(categories, "Id", "Name");
            return View(cat);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                var res = await _adminRepository.UpdateCategory(newCategory.Id, newCategory.Name, newCategory.ParentId);
                await _adminRepository.SaveChanges();
                if (res)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    return View(newCategory);
                }
            }
            var categories = await _adminRepository.getCategories();
            ViewBag.cat = new SelectList(categories, "Id", "Name");
            return View(newCategory);
        }

        public IActionResult Delete(int? id)
         {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var res = await _adminRepository.RemoveCategory(id);
                await _adminRepository.SaveChanges();

                if (res)
                {

                    return RedirectToAction("Index", "Menu");
                }
            }
            return View();
        }
    }
}
