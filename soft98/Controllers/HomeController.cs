using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using soft98.Core.Infrastructure;
using soft98.Core.Interface;
using soft98.Core.ViewModels;
using soft98.DataAccessLayer.Entities;

namespace soft98.Controllers
{
    public class HomeController : Controller
    {
        private IMainMenuRepository _menuRepository;
        private IUserRepository _userRepository;

        public HomeController(IMainMenuRepository menuRepository, IUserRepository userRepository)
        {
            _menuRepository = menuRepository;
            _userRepository = userRepository;
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
        [Route("ShowMatlabById/{id}/{title}")]
        public async Task<IActionResult> ShowMatlabById(int id, string title)
        {
            var products = await _menuRepository.ShowMatlabById(id);
            return View(products);
        }
        public async Task<IActionResult> Search(string Id)
        {
            var products = await _menuRepository.SearchProduct(Id);
            return View(products);
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact != null)
                {
                    await _menuRepository.AddComment(contact);
                    await _menuRepository.Save();
                    return RedirectToAction("Index");
                }
            }

            return View(contact);
        }

        public IActionResult Tarefeh()
        {
            if (User.Identity.IsAuthenticated)
            {

                ViewBag.userid = _userRepository.GetUserId(User.Identity.Name);
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Payment(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var banner = await _menuRepository.ShowBannerById(id);
                var bannerFactor = new BannerFactor()
                {
                    BannerId = banner.Id,
                    UserId = await _userRepository.GetUserId(User.Identity.Name.ToString()),
                    RentDate = null,
                    ExpireDate = null,
                    PayPrice = banner.Price,
                    OrderNumber = CodeGenrators.OrderCode(),
                    FollowNumber = null,
                    IsExpire = false,
                    PicName = null,
                    PicLink = null,
                    SeenNumber = 0
                };

                await _menuRepository.AddBanerFactor(bannerFactor);
                await _menuRepository.Save();

                var payment = new ZarinpalSandbox.Payment(banner.Price);
                var result = payment.PaymentRequest("تراکنش جدید ", "https://localhost:44358/Home/PaymentResult/" + bannerFactor.Id);

                if (result.Result.Status == 100 )
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
                }
                else
                {
                    _menuRepository.RemoveBannerFactor();
                    await _menuRepository.Save();
                    return null;
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [Authorize]
        public async Task<IActionResult> PaymentResult(int id)
        {
            var bannerFactor = await _menuRepository.ShowBannerFactorById(id);
            string authority = HttpContext.Request.Query["Authority"];

            var zarinpal = new ZarinpalSandbox.Payment(bannerFactor.PayPrice);
            var res = zarinpal.Verification(authority).Result;

            if (res.Status == 100)
            {
                var startDate = DateTime.Now.ToLongDateString().ToString();
                var endDate = DateTime.Now.AddDays(30).ToLongDateString().ToString();

                await _menuRepository.UpdateBannerFactor(id, res.RefId.ToString(), startDate, endDate);
                await _menuRepository.Save();

                ViewBag.IsOk = true;
                return View(bannerFactor);
            }
            else
            {
                ViewBag.IsOk = false;
            }

            return View(bannerFactor);
        }
        [Authorize]
        public  IActionResult Edit(int id)
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateImgViewModel updateImgView, int id)
        {
            if (ModelState.IsValid)
            {
                if (updateImgView.PicFile != null)
                {
                    string PicPath = "";
                    updateImgView.PicAddress = CodeGenrators.ProductCode() + Path.GetExtension(updateImgView.PicFile.FileName);
                    PicPath = Path.Combine(Directory.GetCurrentDirectory()  ,"wwwroot/Images/",
                                           updateImgView.PicAddress);
                    using (var stream = new FileStream(PicPath , FileMode.Create))
                    {
                        await updateImgView.PicFile.CopyToAsync(stream);
                    }

                    await _menuRepository.UpdateBannerFactorImage(id, updateImgView.PicAddress, updateImgView.Link);
                    await _menuRepository.Save();
                  
                }
                return RedirectToAction("Index");
            }

            return View(updateImgView);
        }
    }
}
