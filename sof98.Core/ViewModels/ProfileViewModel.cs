using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace soft98.Core.ViewModels
{
   public class ProfileViewModel
    {
        [Display(Name ="شماره موبایل جدید")]
        [MaxLength(11,ErrorMessage ="مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Phone { get; set; }

        [Display(Name = "رمز عبور قبلی")]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string CurrentPassword { get; set; }

        [Display(Name = "رمز عبور جدید")]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Password { get; set; }

        [Display(Name = "تایید رمز عبور جدید")]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        [Compare("Password", ErrorMessage = "رمز عبور با تایید برابر نیست")]
        public string RePassword { get; set; }
    }
}
