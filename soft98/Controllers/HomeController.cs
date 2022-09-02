using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soft98.Core.Interface;

namespace soft98.Controllers
{
    public class HomeController : Controller
    {
        private IMainMenuRepository _menuRepository;

        public HomeController(IMainMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Detail/{id}/{title}")]
        public async Task<IActionResult> Detail(int id, string title)
        {
            var productD = await _menuRepository.ShowProductsById(id);
            return View(productD);
        }

        public async Task<IActionResult> UpdateNumberDownload(int Id)
        {
            var File = await _menuRepository.UpdateFileDownloads(Id);

            return Redirect("~/Files/" + File.FileName);
        }
        [Route("ShowProductByCategory/{id}/{title}")]
        public async Task<IActionResult> ShowProductByCategory(int id, string title)
        {
            var products = await _menuRepository.ShowProductByCatId(id);
            return View(products);
        }
    }
}
