using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace soft98.Core.ViewModels
{
    public class ResetViewModel
    { 
        [DisplayName("کد تایید")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(6,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Code { get; set; }

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