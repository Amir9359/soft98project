using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace soft98.Core.ViewModels
{
    public class RegisterViewModel
    { 
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(11,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Phone { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Password { get; set; }

        [DisplayName("تایید رمز عبور")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        [Compare("Password", ErrorMessage = "رمز عبور با تایید برابر نیست")]
        public string RePassword { get; set; }
    }
}