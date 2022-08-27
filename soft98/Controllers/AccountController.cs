using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using reCAPTCHA.AspNetCore;
using soft98.Core.Interface;
using soft98.Core.ViewModels;
using soft98.DataAccessLayer.Entities;
using soft98.Core.Infrastructure;

namespace soft98.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private IRecaptchaService _recaptcha;

        public AccountController(IUserRepository userRepository, IRecaptchaService recaptcha)
        {
            _userRepository = userRepository;
            _recaptcha = recaptcha;
        }

        public IActionResult Register()
        {
            ViewBag.mystatus = 0;
            ViewBag.ModalTitle = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var recaptcha = await _recaptcha.Validate(Request);
                if (!recaptcha.success)
                {
                    ModelState.AddModelError("Recaptcha", "لطفا تاییده recatcha  را انجام دهید.");
                    ViewBag.mystatus = 0;
                    return View(register);
                }
                else
                {
                    if (_userRepository.PhoneExist(register.Phone))
                    {
                        ModelState.AddModelError("Phone", " با این شماره ثبت نام انجام شده است. ");
                        ViewBag.mystatus = 1;
                        ViewBag.ModalTitle = "ورود به سایت";
                        return View();
                    }
                    else
                    {
                        var user = new User
                        {
                            IsActive = false,
                            Phone = register.Phone,
                            Password = HashGenrator.EncondingPassWithMd5(register.Password),
                            Code = CodeGenrators.ActiveCode(),
                            RoleId = 2
                        };
                        await _userRepository.AddUser(user);
                        await _userRepository.SaveShanges();

                        SMS sms = new SMS();
                        sms.Send(user.Phone, "ثبت نام شما انجام شد  کد فعال سازی شما : " + user.Code);

                        ViewBag.mystatus = 2;
                        ViewBag.ModalTitle = "فعال سازی رمز عبور ";
                        return View();
                    }
                }

            }
            else
            {
                return View(register);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModels loginView)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Login(loginView.Phone, loginView.Password);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        var Claims = new List<Claim>()
                      {
                          new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                          new Claim(ClaimTypes.Name, user.Phone)
                      };
                        var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(principal);

                        if (await _userRepository.GetRoleName(user.RoleId) == "admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {

                        ViewBag.mystatus = 2;
                        ViewBag.ModalTitle = "فعال سازی حساب";
                        return View("Register");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "تلفن یا رمز عبور اشتباه است!");
                    ViewBag.mystatus = 1;
                    ViewBag.ModalTitle = "ورود به حساب کاربری";
                    return View("Register");
                }

            }
            else
            {
                ModelState.AddModelError("Password", "تلفن یا رمز عبور اشتباه است!");
                ViewBag.mystatus = 1;
                ViewBag.ModalTitle = "ورود به حساب کاربری";
                return View("Register");
            }

        }

        public IActionResult Active()
        {
 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Active(ActiveViewModel active)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.ActiveUser(active.Code);
                if (user != null)
                {
                    var login = new LoginViewModels() { Password = user.Password, Phone = user.Phone };
                    await Login(login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Code", "کد فعال سازی صحیح نمی باشد");
                    return View(active);

                }

            }
            else
            {
                return View(active);
            }
        }
        public IActionResult ForgetPassword()
        {
       
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetViewModel forget)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.ForgetPassword(forget.Phone);
                if (user != null)
                {
                    var sms = new SMS();
                    sms.Send(forget.Phone,"کد تایید برای تغییر رمز عبور " + user.Code + " می باشد.");
                    return View("ResetPassword");
                }
                else
                {
                    ModelState.AddModelError("Phone", "کاربری با این شماره تلفن وجود ندارد");
                    return View(forget);
                }
            }
            else
            {
                return View(forget);
            }
        }
        public IActionResult ResetPassword()
        {
            ViewBag.mystatus = 0;
            ViewBag.ModalTitle = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.ResetPassword(reset.Code, reset.Password);
                if (user != null)
                {

                    ViewBag.mystatus = 1;
                    ViewBag.ModalTitle = "ورود به سایت";
                    return View("ResetPassword");
                }
                else
                {
                    ModelState.AddModelError("Code", "کد وارد شده صحیح نمی باشد");
                    return View(reset);

                }
            }
            else
            {
                return View(reset);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel profile)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userid = await _userRepository.GetUserId(User.Identity.Name);

                    if (userid != 0)
                    {
                        if (profile.Phone == null && profile.CurrentPassword != null && profile.Password != null)
                        {
                            if (await _userRepository.ChangePassword(User.Identity.Name, profile.CurrentPassword,
                                    profile.Password))
                            {
                                return RedirectToAction("SignOut");
                            }
                            else
                            {
                                ModelState.AddModelError("currentPassword", "کلمه عبور فعلی اشتباه است.");
                                return View(profile);
                            }
                        }
                        else if (profile.Phone != null && profile.CurrentPassword != null && profile.Password != null)
                        {
                            if (await _userRepository.ProfileUser(profile.Phone, userid))
                            {
                                if (await _userRepository.ChangePassword(profile.Phone, profile.CurrentPassword,
                                        profile.Password))
                                {
                                    return RedirectToAction("SignOut");
                                }
                                else
                                {
                                    ModelState.AddModelError("currentPassword", "کلمه عبور فعلی اشتباه است.");
                                    return View(profile);
                                }
                            }
            
 
                            else 
                            {
                                ModelState.AddModelError("Phone", "کاربری با این شماره موبایل قبلا ثبت نام کرده است");
                                return View(profile);
                            }
                        }
                        else if (profile.Phone != null)
                        {
                            if (await _userRepository.ProfileUser(profile.Phone, userid))
                            {
                                return RedirectToAction("SignOut");
                            }
                            else
                            {
                                ModelState.AddModelError("currentPassword", "کلمه عبور فعلی اشتباه است.");
                                return View(profile);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("currentPassword", "شماره موبایل جدید یا رمز عبور جدید وارد کنید.");
                            return View(profile);
                        }
                   
                    }
                    else
                    {
                        ModelState.AddModelError("Phone", "با شماره وارد شده قبلا ثبت نام شده است");
                        return View(profile);
                    }
                }
                else
                {
                    ModelState.AddModelError("Phone", "شما وارد سایت نشده اید.");
                    ViewBag.mystatus = 1;
                    ViewBag.ModalTitle = "ورود به حساب کاربری";
                    return RedirectToAction("Register");
                }
            }
            else
            {
                return View(profile);
            }
        }
    }
}
